using System;
using System.Collections.Generic;

namespace UnyimeWebApp.Models;

public partial class InitiativeMedium
{
    public int InitiativeMediaId { get; set; }

    public int? InitiativeId { get; set; }

    public string Title { get; set; } = null!;

    public string? MediaFormat { get; set; }

    public string MediaLink { get; set; } = null!;

    public string AlternativeText { get; set; } = null!;

    public virtual Initiative? Initiative { get; set; }
}
