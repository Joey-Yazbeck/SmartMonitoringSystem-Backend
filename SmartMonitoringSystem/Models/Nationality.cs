using System;
using System.Collections.Generic;

namespace SmartMonitoringSystem.Models;

public partial class Nationality
{
    public long NationalityId { get; set; }

    public string Nationality1 { get; set; } = null!;

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();
}
