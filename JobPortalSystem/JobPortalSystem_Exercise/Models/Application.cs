using System;
using System.Collections.Generic;

namespace JobPortalSystem_Exercise.Models;

public partial class Application
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid JobId { get; set; }

    public Guid CompanyId { get; set; }

    public DateTime? AppliedDate { get; set; }

    public string? Status { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Job Job { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
