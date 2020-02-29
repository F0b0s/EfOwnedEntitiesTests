using Microsoft.EntityFrameworkCore;

namespace DataModel
{
    public sealed class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Company> builder)
        {
            builder
                .OwnsOne<Settings>(
                    "Settings",
                    ps =>
                    {
                        ps.Property(p => p.StandartAccess)
                            .IsRequired()
                            .HasDefaultValue(false);
                        ps.Property(p => p.ExtendedAcces)
                            .IsRequired()
                            .HasDefaultValue(false);
                        ps.Property(p => p.Flag1)
                            .IsRequired()
                            .HasDefaultValue(false);
                    });
        }
    }
}
