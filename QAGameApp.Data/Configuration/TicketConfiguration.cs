using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QAGameApp.Data.Models;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
	public void Configure(EntityTypeBuilder<Ticket> builder)
	{
		builder.HasKey(t => t.Id);

		builder
			.Property(t => t.Name)
			.HasMaxLength(250)
			.IsRequired();

		builder
			.Property(t => t.Description)
			.HasMaxLength(1000)
			.IsRequired();

		builder
			.Property(t => t.IsResolved)
			.HasDefaultValue(false);

		builder
			.HasOne(t => t.AssignedDeveloper)
			.WithMany(d => d.AssignedTickets)
			.HasForeignKey(t => t.AssignedDeveloperId)
			.OnDelete(DeleteBehavior.SetNull);

		builder
			.HasOne(t => t.GameBuild)
			.WithMany(gb => gb.Tickets)
			.HasForeignKey(t => t.GameBuildId)
			.OnDelete(DeleteBehavior.Cascade);

		builder
			.HasOne(t => t.SubmittedByUser)
			.WithMany()
			.HasForeignKey(t => t.SubmittedByUserId)
			.OnDelete(DeleteBehavior.SetNull);
	}
}
