using System;
using System.Collections.Generic;

namespace SmartMonitoringSystem.Models;

public partial class FamilyStatus
{
    public long FamilyStatusId { get; set; }

    public string FamilyStatus1 { get; set; } = null!;

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();
}
