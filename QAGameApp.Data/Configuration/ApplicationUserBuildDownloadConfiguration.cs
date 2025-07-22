using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAGameApp.Data.Models;

public class ApplicationUserBuildDownloadConfiguration : IEntityTypeConfiguration<ApplicationUserBuildDownload>
{
	public void Configure(EntityTypeBuilder<ApplicationUserBuildDownload> builder)
	{
		builder
			.HasKey(d => new { d.ApplicationUserId, d.GameBuildId });

		builder
			.Property(d => d.IsDeleted)
			.HasDefaultValue(false);

		builder
			.HasOne(d => d.ApplicationUser)
			.WithMany()
			.HasForeignKey(d => d.ApplicationUserId)
			.OnDelete(DeleteBehavior.Restrict);

		builder
			.HasOne(d => d.GameBuild)
			.WithMany()
			.HasForeignKey(d => d.GameBuildId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
