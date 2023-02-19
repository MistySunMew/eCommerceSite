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
}
