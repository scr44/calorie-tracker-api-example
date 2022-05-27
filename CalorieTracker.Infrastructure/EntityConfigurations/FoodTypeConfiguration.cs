using CalorieTracker.Domain.FoodTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTracker.Infrastructure.EntityConfigurations;

public class FoodTypeConfiguration : IEntityTypeConfiguration<FoodType>
{
    public void Configure(EntityTypeBuilder<FoodType> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
