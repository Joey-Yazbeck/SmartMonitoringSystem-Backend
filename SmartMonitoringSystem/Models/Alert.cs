using System;
using System.Collections.Generic;

namespace SmartMonitoringSystem.Models;

public partial class Alert
{
    public long AlertId { get; set; }

    public bool IsRead { get; set; }

    public long? TargetId { get; set; }

    public string Message { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public virtual Target? Target { get; set; }
}
