using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Drop
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;
}
