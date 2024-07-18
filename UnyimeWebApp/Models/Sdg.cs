using System;
using System.Collections.Generic;

namespace UnyimeWebApp.Models;

public partial class Sdg
{
    public int SdgId { get; set; }

    public int? SdgNumber { get; set; }

    public string? ShortForm { get; set; }

    public string? LongForm { get; set; }

    public byte[]? Color { get; set; }

    public string? LogoLink { get; set; }

    public virtual ICollection<Initiative> Initiatives { get; set; } = new List<Initiative>();

    public virtual ICollection<Entity> Entities { get; set; } = new List<Entity>();

    public virtual ICollection<Individual> Individuals { get; set; } = new List<Individual>();

    public virtual ICollection<Initiative> InitiativesNavigation { get; set; } = new List<Initiative>();
}
