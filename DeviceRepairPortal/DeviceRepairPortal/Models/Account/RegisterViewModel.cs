using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeviceRepairPortal.Models.Account
{
	public class RegisterViewModel
    {
        [DisplayName("Username")]
        [Required]
        public string Username { get; set; }

        [DisplayName("E-mail")]
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[DisplayName("Parola")]
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[DisplayName("Confirm password")]
		[Compare("Password", ErrorMessage = "The passwords did not match.")]
		public string ConfirmPassword { get; set; }
	}
}