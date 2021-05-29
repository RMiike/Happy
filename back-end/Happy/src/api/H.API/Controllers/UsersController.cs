using H.BuildingBlocks.Helpers;
using H.Domain.Entities;
using H.Domain.MapperEntities;
using H.Domain.Models;
using H.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace H.API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly SignInManager<IdentityUser> __signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly IMailService _mailService;
        public UsersController(SignInManager<IdentityUser> signInManager,
                               UserManager<IdentityUser> userManager,
                                IOptions<AppSettings> appSettings,
                                IMailService mailService)
        {
            __signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _mailService = mailService;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpUserModel signUpUserModel)
        {
            var signUpUser = signUpUserModel.ConvertToSignUp();
            if (!signUpUser.IsValid())
                return CustomResponse(signUpUser.ValidationResult);

            var user = new IdentityUser
            {
                UserName = signUpUser.Email,
                Email = signUpUser.Email,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, signUpUser.Password);
            if (result.Succeeded)
            {
                return CustomResponse(await GenerateJWT(user.Email));
            }
            foreach (var erro in result.Errors)
            {
                AdicionarErroProcessamento(erro.Description);
            }
            return CustomResponse();
        }
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInUserModel signInUserModel)
        {
            var signInUser = signInUserModel.ConvertToSignIn();
            if (!signInUser.IsValid())
                return CustomResponse(signInUser.ValidationResult);

            var result = await __signInManager.PasswordSignInAsync(signInUser.Email, signInUser.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await GenerateJWT(signInUser.Email));
            }

            if (result.IsLockedOut)
            {
                AdicionarErroProcessamento("Usuário temporariamente bloqueado por tentativas inválidas.");
                return CustomResponse();
            }
            AdicionarErroProcessamento("Usuário ou senha incorretos.");
            return CustomResponse("");
        }

        [HttpPost("forgot-pass")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel forgotPasswordModel)
        {
            var forgotEntity = forgotPasswordModel.ConvertToEntity();
            if (!forgotEntity.IsValid())
                return CustomResponse(forgotEntity.ValidationResult);


            var user = await _userManager.FindByEmailAsync(forgotEntity.Email);

            if (user == null)
            {
                AdicionarErroProcessamento("Nova senha foi enviado ao email.");
                return CustomResponse();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await ResetPassword(user, token).ConfigureAwait(false);

            if (string.IsNullOrEmpty(result))
                return CustomResponse();

            await _mailService.SendEmailAsync(
              user.Email,
              "Forgot password.",
              "<h1>Acess with your new password and change. </h1>" +
              $"<p>Your new password is: {result} </p>");

            return CustomResponse();
        }

        [HttpPost("change-pass")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            var entity = model.ConvertToEntity();
            if (!entity.IsValid())
                return CustomResponse(entity.ValidationResult);

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                AdicionarErroProcessamento("Usuário inválido.");
                return CustomResponse();
            }

            var result = await _userManager.ChangePasswordAsync(user, entity.OldPassword, entity.NewPassword);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    AdicionarErroProcessamento(error.Description);
                }
                return CustomResponse();
            }

            return CustomResponse("Password was changed successfully.");
        }
        private async Task<string> ResetPassword(IdentityUser user, string token)
        {
            if (user == null || string.IsNullOrWhiteSpace(token))
            {
                AdicionarErroProcessamento("Usuário inválido ou token expirado.");
                return string.Empty;
            }

            var randomPassword = $"P{Guid.NewGuid().ToString().Replace("-", "@")}";

            var result = await _userManager.ResetPasswordAsync(user,
                     token, randomPassword);

            if (!result.Succeeded)
            {
                var erros = result.Errors.Select(error => error.Description);
                foreach (var erro in erros)
                {
                    AdicionarErroProcessamento(erro);
                }
                return string.Empty;

            }
            return randomPassword;
        }
        private async Task<SignInUserResponse> GenerateJWT(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);

            var identityClaims = await ObterClaimsUsuario(claims, user);

            var encodedToken = CodificarToken(identityClaims);

            return ObterRespostaToken(encodedToken, user, claims);
        }
        private async Task<ClaimsIdentity> ObterClaimsUsuario(ICollection<Claim> claims, IdentityUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.UtcNow.ToUnixEpochDate().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToUnixEpochDate().ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);
            return identityClaims;
        }
        private string CodificarToken(ClaimsIdentity claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience,
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }
        private SignInUserResponse ObterRespostaToken(string encodedToken, IdentityUser user, IEnumerable<Claim> claims)
        {

            var response = new SignInUserResponse
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpirationHours).TotalSeconds,
                UserToken = new UserToken
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(x => new UserClaim { Type = x.Type, Value = x.Value })
                }
            };
            return response;
        }
    }
}
