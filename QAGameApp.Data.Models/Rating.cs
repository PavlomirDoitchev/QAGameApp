using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace QAGameApp.Data.Models
{

	[Comment("User rating for a specific game build")]
	public class Rating
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		[Comment("The rating score from 1 to 5")]
		public int Score { get; set; }

		[Comment("Optional comment from the user")]
		public string? Comment { get; set; }

		[Comment("Foreign key to the user who submitted the rating")]
		public string UserId { get; set; } = null!;
		public virtual IdentityUser User { get; set; } = null!;

		[Comment("Foreign key to the rated build")]
		public Guid GameBuildId { get; set; }
		public virtual GameBuild GameBuild { get; set; } = null!;

		[Comment("Timestamp of submission")]
		public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

		public bool IsDeleted { get; set; } = false;
	}
}