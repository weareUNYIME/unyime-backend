using System;
using System.Collections.Generic;

namespace UnyimeWebApp.Models;

public partial class IndividualDonation
{
    public int IndividualDonationId { get; set; }

    public int? IndividualId { get; set; }

    public int? InitiativeId { get; set; }

    public string Currency { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime? DonationDate { get; set; }

    public virtual Individual? Individual { get; set; }

    public virtual Initiative? Initiative { get; set; }
}
