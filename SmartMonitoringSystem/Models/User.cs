using System;
using System.Collections.Generic;

namespace SmartMonitoringSystem.Models;

public partial class User
{
    public long UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;
}
