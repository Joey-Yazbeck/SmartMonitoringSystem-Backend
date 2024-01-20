using System;
using System.Collections.Generic;

namespace SmartMonitoringSystem.Models;

public partial class WarrantStatus
{
    public long WarrantStatusId { get; set; }

    public string WarrantStatus1 { get; set; } = null!;

    public virtual ICollection<Warrant> Warrants { get; set; } = new List<Warrant>();
}
