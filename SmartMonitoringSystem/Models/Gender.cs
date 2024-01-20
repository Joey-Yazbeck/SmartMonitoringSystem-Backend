using System;
using System.Collections.Generic;

namespace SmartMonitoringSystem.Models;

public partial class Gender
{
    public long GenderId { get; set; }

    public string Gender1 { get; set; } = null!;

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();
}
