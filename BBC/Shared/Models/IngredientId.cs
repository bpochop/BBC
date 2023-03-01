using System;
using System.Collections.Generic;

namespace BBC.Shared.Models;

public partial class IngredientId
{
    public string Ingredient { get; set; } = null!;

    public string Dtype { get; set; } = null!;

    public string PumpPicture { get; set; } = null!;
}
