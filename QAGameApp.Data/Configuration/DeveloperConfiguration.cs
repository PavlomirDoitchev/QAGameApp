using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAGameApp.Data.Models;

public class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
{
	public void Configure(EntityTypeBuilder<Developer> builder)
	{
		builder.HasKey(d => d.Id);

		builder
			.Property(d => d.IsDeleted)
			.HasDefaultValue(false);

		builder
			.HasOne(d => d.User)
			.WithMany()
			.HasForeignKey(d => d.UserId)
			.OnDelete(DeleteBehavior.Restrict);

		builder
			.HasMany(d => d.AssignedTickets)
			.WithOne()
			.OnDelete(DeleteBehavior.SetNull);

		builder
			.HasMany(d => d.ManagedBuilds)
			.WithOne(gb => gb.Developer)
			.HasForeignKey(gb => gb.DeveloperId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}