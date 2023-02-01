using System;
using System.Collections.Generic;

namespace BBC.Shared.BBC.Shared.Models;

public partial class Progress
{
    public long Id { get; set; }

    public string InProgress { get; set; } = null!;
}
