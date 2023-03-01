using System;
using System.Collections.Generic;

namespace BBC.Shared.Models;

public partial class DisplaySetting
{
    public long Id { get; set; }

    public string Color { get; set; } = null!;

    public long DrinksPerRow { get; set; }
}
