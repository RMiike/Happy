namespace H.Domain.Models
{
    public class SignInUserModel
    {
        public SignInUserModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
