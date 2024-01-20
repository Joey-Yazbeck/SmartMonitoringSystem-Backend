using System;
using System.Collections.Generic;

namespace SmartMonitoringSystem.Models;

public partial class Role
{
    public long RoleId { get; set; }

    public string Role1 { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
