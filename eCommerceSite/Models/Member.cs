using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Models
{
	public class Member
	{
		[Key]
		public int MemberID { get; set; }

		[Required] //This should be the primary key
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		public string Phone { get; set; }

		public string Username { get; set; }
	}

	[Keyless]
	public class RegisterViewModel
	{
		[Required]
		[EmailAddress]
		[StringLength(100)]
		public string Email { get; set; }
		
		[Required]
		[Compare(nameof(Email))]
		[Display(Name = "Confirm Email")]
		public string ConfirmEmail { get; set; }
		
		[Required]
		[DataType(DataType.Password)]
		[StringLength(100, MinimumLength = 6)]
		public string Password { get; set; }
		
		[Required]
		[Compare(nameof(Password))]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		public string ConfirmPassword { get; set; }
	}
}
