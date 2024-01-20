using System;
using System.Collections.Generic;

namespace SmartMonitoringSystem.Models;

public partial class TargetStatus
{
    public long TargetStatusId { get; set; }

    public string TargetStatus1 { get; set; } = null!;

    public virtual ICollection<Target> Targets { get; set; } = new List<Target>();
}
