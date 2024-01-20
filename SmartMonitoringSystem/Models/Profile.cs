using System;
using System.Collections.Generic;

namespace SmartMonitoringSystem.Models;

public partial class Profile
{
    public long ProfileId { get; set; }

    public string FullName { get; set; } = null!;

    public string MotherName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public long GenderId { get; set; }

    public long NationalityId { get; set; }

    public long FamilyStatusId { get; set; }

    public virtual FamilyStatus FamilyStatus { get; set; } = null!;

    public virtual Gender Gender { get; set; } = null!;

    public virtual Nationality Nationality { get; set; } = null!;

    public virtual Target? Target { get; set; }

    public virtual ICollection<Warrant> Warrants { get; set; } = new List<Warrant>();
}
