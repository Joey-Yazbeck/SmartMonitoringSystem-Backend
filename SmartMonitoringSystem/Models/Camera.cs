using System;
using System.Collections.Generic;

namespace SmartMonitoringSystem.Models;

public partial class Camera
{
    public long CameraId { get; set; }

    public string CameraType { get; set; } = null!;

    public string CameraLocation { get; set; } = null!;

    public virtual ICollection<Suspect> Suspects { get; set; } = new List<Suspect>();
}
