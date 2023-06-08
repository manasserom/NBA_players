using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Favorite
{
    public string Email { get; set; } = null!;

    public long IdPlayer { get; set; }
}
