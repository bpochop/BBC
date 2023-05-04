using System;
using System.Collections.Generic;

namespace BBC.Shared.Models;

public partial class Menuitem
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string CreatorId { get; set; } = null!;

    public string TypeId { get; set; } = null!;

    public string Picture { get; set; } = null!;

    public int Count { get; set; }  
}
