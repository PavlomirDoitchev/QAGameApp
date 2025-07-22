using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace QAGameApp.Data.Models
{

	[Comment("Tracks which users have downloaded which game builds.")]
	public class ApplicationUserBuildDownload
	{
		[Comment("Foreign key to the user (IdentityUser). Part of composite PK.")]
		public string ApplicationUserId { get; set; } = null!;
		public virtual IdentityUser ApplicationUser { get; set; } = null!;

		[Comment("Foreign key to the downloaded game build. Part of composite PK.")]
		public Guid GameBuildId { get; set; }
		public virtual GameBuild GameBuild { get; set; } = null!;

		[Comment("Date/time of download.")]
		public DateTime DownloadedAt { get; set; } = DateTime.UtcNow;

		[Comment("Shows if the download entry is deleted.")]
		public bool IsDeleted { get; set; } = false;
	}
}