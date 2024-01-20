using System;
using System.Collections.Generic;

namespace SmartMonitoringSystem.Models;

public partial class Target
{
    public long TargetId { get; set; }

    public long ProfileId { get; set; }

    public long TargetStatusId { get; set; }

    public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();

    public virtual Photo? Photo { get; set; }

    public virtual Profile Profile { get; set; } = null!;

    public virtual TargetStatus TargetStatus { get; set; } = null!;
}
