using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeviceRepairPortal.Models.Account
{
	public class LoginViewModel
	{
		[DisplayName("Email")]
		[Required]
		public string Email { get; set; }

		[DisplayName("Password")]
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember Me")]
		public bool RememberMe { get; set; }
	}
}