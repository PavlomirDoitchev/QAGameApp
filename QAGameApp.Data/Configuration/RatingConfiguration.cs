using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAGameApp.Data.Models;

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
	public void Configure(EntityTypeBuilder<Rating> builder)
	{
		builder.HasKey(r => r.Id);

		builder
			.Property(r => r.Score)
			.IsRequired();

		builder
			.Property(r => r.IsDeleted)
			.HasDefaultValue(false);

		builder
			.HasOne(r => r.User)
			.WithMany()
			.HasForeignKey(r => r.UserId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}