using System;
using System.Collections.Generic;

namespace BBC.Shared.Models;

public partial class Pump
{
    public long PumpID { get; set; }

    public string IngredientId { get; set; } = null!;

    public long VolumeLeft { get; set; }
}
