namespace QAGameApp.Data.Models
{
	public class GameBuild
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public string Version { get; set; } = null!;
		public DateTime ReleaseDate { get; set; } = DateTime.UtcNow;
		public string DownloadUrl { get; set; } = null!;
		public string ReleaseNotes { get; set; } = null!;
		public bool IsDeleted { get; set; } = false;

		// Relations
		public Guid DeveloperId { get; set; }
		public virtual Developer Developer { get; set; } = null!;

		public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
		public virtual ICollection<Rating> Ratings { get; set; } = new HashSet<Rating>();
	}
}