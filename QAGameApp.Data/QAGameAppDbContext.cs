using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QAGameApp.Data.Models;
using System.Reflection;

namespace QAGameApp.Data
{
	public class QAGameAppDbContext : IdentityDbContext
	{
		public QAGameAppDbContext(DbContextOptions<QAGameAppDbContext> options)
			: base(options)
		{}
		public virtual DbSet<GameBuild> GameBuilds { get; set; } = null!;
		public virtual DbSet<Ticket> Tickets { get; set; } = null!;
		public virtual DbSet<Developer> Developers { get; set; } = null!;
		public virtual DbSet<Rating> Ratings { get; set; } = null!;
		public virtual DbSet<ApplicationUserBuildDownload> RatingComments { get; set; } = null!;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
