using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace QAGameApp.Data.Models
{

	[Comment("User submitted tickets")]
	public class Ticket
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		[Required]
		public string Name { get; set; } = null!;

		[Required]
		public string Description { get; set; } = null!;

		[Comment("True if the issue is resolved")]
		public bool IsResolved { get; set; } = false;

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		[Required]
		public string JsonFilePath { get; set; } = null!;

		// Relations
		public string? SubmittedByUserId { get; set; }
		public virtual IdentityUser? SubmittedByUser { get; set; }

		public Guid GameBuildId { get; set; }
		public virtual GameBuild GameBuild { get; set; } = null!;

		public Guid? AssignedDeveloperId { get; set; }
		public virtual Developer? AssignedDeveloper { get; set; }

		public bool IsDeleted { get; set; } = false;
	}
}