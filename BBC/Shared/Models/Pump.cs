using System;
using System.Collections.Generic;

namespace BBC.Shared.Models;

public partial class Pump
{
    public long Pump1 { get; set; }

    public string IngredientId { get; set; } = null!;

    public long VolumeLeft { get; set; }
}
