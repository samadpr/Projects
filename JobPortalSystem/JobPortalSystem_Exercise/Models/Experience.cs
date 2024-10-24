using System;
using System.Collections.Generic;

namespace JobPortalSystem_Exercise.Models;

public partial class Experience
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string? JobTitle { get; set; }

    public string? Company { get; set; }

    public string? Duration { get; set; }

    public string? Year { get; set; }

    public virtual User User { get; set; } = null!;
}
