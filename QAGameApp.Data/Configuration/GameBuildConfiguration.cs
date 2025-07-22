using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAGameApp.Data.Models;

public class GameBuildConfiguration : IEntityTypeConfiguration<GameBuild>
{
	public void Configure(EntityTypeBuilder<GameBuild> builder)
	{
		builder.HasKey(gb => gb.Id);

		builder
			.Property(gb => gb.IsDeleted)
			.HasDefaultValue(false);

		builder
			.Property(gb => gb.Version)
			.IsRequired();

		builder
			.Property(gb => gb.DownloadUrl)
			.HasMaxLength(2048)
			.IsRequired();

		builder
			.HasMany(gb => gb.Tickets)
			.WithOne()
			.OnDelete(DeleteBehavior.Cascade);

		builder
			.HasMany(gb => gb.Ratings)
			.WithOne(r => r.GameBuild)
			.HasForeignKey(r => r.GameBuildId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
