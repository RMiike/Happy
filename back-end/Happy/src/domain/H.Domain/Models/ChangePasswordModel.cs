namespace H.Domain.Models
{
    public class ChangePasswordModel
    {
        public ChangePasswordModel(string oldPassword, string newPassword, string confirmPassword)
        {
            OldPassword = oldPassword;
            NewPassword = newPassword;
            ConfirmPassword = confirmPassword;
        }

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
