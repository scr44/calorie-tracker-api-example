using CalorieTracker.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTracker.Domain.FoodTypes.DTO;

public class UpdateFoodTypeDto
{
    public int Id { get; set; }
    public string? Name { get; init; }
    public double? CaloriesPerUnit { get; init; }
    public Units? Units { get; init; }
}
