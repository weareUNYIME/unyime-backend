using System;
using System.Collections.Generic;

namespace UnyimeWebApp.Models;

public partial class IndividualExperience
{
    public int IndividualExperienceId { get; set; }

    public int? IndividualId { get; set; }

    public int? ApplicationId { get; set; }

    public virtual IndividualApplication? Application { get; set; }

    public virtual Individual? Individual { get; set; }

    public virtual ICollection<IndividualReview> IndividualReviews { get; set; } = new List<IndividualReview>();
}
