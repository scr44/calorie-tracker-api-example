using CalorieTracker.Domain.CalorieEntries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTracker.Infrastructure.EntityConfigurations;

public class CalorieEntryConfiguration : IEntityTypeConfiguration<CalorieEntry>
{
    public void Configure(EntityTypeBuilder<CalorieEntry> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
