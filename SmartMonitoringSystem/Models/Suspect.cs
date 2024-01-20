using System;
using System.Collections.Generic;

namespace SmartMonitoringSystem.Models;

public partial class Suspect
{
    public long SuspectId { get; set; }

    public DateOnly CaptureDate { get; set; }

    public long CameraId { get; set; }

    public long PhotoId { get; set; }

    public virtual Camera Camera { get; set; } = null!;

    public virtual Photo Photo { get; set; } = null!;
}
