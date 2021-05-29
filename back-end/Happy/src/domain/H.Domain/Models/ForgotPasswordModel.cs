namespace H.Domain.Models
{
    public class ForgotPasswordModel
    {
        public ForgotPasswordModel(string email)
        {
            Email = email;
        }
        public string Email { get; set; }
    }
}
