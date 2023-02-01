using System;
using System.Collections.Generic;

namespace BBC.Shared.BBC.Shared.Models;

public partial class Menu
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string CreatorId { get; set; } = null!;

    public string TypeId { get; set; } = null!;

    public string Picture { get; set; } = null!;
}
