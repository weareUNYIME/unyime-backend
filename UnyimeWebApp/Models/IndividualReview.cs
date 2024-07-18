using System;
using System.Collections.Generic;

namespace UnyimeWebApp.Models;

public partial class IndividualReview
{
    public int IndividualReviewId { get; set; }

    public int? IndividualId { get; set; }

    public int? IndividualExperienceId { get; set; }

    public string? Review { get; set; }

    public int? Rating { get; set; }

    public virtual Individual? Individual { get; set; }

    public virtual IndividualExperience? IndividualExperience { get; set; }
}
