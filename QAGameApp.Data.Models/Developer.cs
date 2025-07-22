using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace QAGameApp.Data.Models
{

	[Comment("Developer in the system")]
	public class Developer
	{
		[Comment("Developer identifier")]
		public Guid Id { get; set; }

		public bool IsDeleted { get; set; }

		[Comment("User identity reference")]
		public string UserId { get; set; } = null!;
		public virtual IdentityUser User { get; set; } = null!;

		[Comment("Tickets assigned to this developer for review")]
		public virtual ICollection<Ticket> AssignedTickets { get; set; } = new HashSet<Ticket>();

		[Comment("Game builds managed by the developer")]
		public virtual ICollection<GameBuild> ManagedBuilds { get; set; } = new HashSet<GameBuild>();
	}
}