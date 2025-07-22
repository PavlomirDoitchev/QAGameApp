using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAGameApp.Data.Models;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
	public void Configure(EntityTypeBuilder<Ticket> builder)
	{
		builder.HasKey(t => t.Id);

		builder
			.Property(t => t.Name)
			.IsRequired();

		builder
			.Property(t => t.Description)
			.IsRequired();

		builder
			.Property(t => t.IsResolved)
			.HasDefaultValue(false);
	}
}
