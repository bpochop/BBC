using System;
using System.Collections.Generic;

namespace BBC.Shared.BBC.Shared.Models;

public partial class Ratio
{
    public long Id { get; set; }

    public string Ingredient { get; set; } = null!;

    public long MenuId { get; set; }

    public string Amount { get; set; } = null!;
}
