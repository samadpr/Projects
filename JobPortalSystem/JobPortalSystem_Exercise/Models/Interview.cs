using System;
using System.Collections.Generic;

namespace JobPortalSystem_Exercise.Models;

public partial class Interview
{
    public Guid Id { get; set; }

    public Guid? JobId { get; set; }

    public Guid? JobseekerId { get; set; }

    public Guid? CompanyId { get; set; }

    public DateTime? Date { get; set; }

    public TimeOnly? Time { get; set; }

    public string? Location { get; set; }

    public string? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Company? Company { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Job? Job { get; set; }

    public virtual User? Jobseeker { get; set; }
}
