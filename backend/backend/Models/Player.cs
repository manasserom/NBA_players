using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Player
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public long? HeightFeet { get; set; }

    public long? HeightInches { get; set; }

    public long? WeightPounds { get; set; }

    public long TeamId { get; set; }
}
