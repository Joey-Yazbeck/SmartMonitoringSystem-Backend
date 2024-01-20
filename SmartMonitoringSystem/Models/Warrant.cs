using System;
using System.Collections.Generic;

namespace SmartMonitoringSystem.Models;

public partial class Warrant
{
    public long WarrantId { get; set; }

    public DateOnly IssueDate { get; set; }

    public string Location { get; set; } = null!;

    public string JudgeName { get; set; } = null!;

    public string CrimeDescription { get; set; } = null!;

    public long ProfileId { get; set; }

    public long WarrantStatusId { get; set; }

    public virtual Profile Profile { get; set; } = null!;

    public virtual WarrantStatus WarrantStatus { get; set; } = null!;
}
