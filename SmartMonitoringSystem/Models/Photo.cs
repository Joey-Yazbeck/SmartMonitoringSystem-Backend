using System;
using System.Collections.Generic;

namespace SmartMonitoringSystem.Models;

public partial class Photo
{
    public long PhotoId { get; set; }

    public string? Photo1 { get; set; }

    public long? TargetId { get; set; }

    public virtual Suspect? Suspect { get; set; }

    public virtual Target? Target { get; set; }
}
