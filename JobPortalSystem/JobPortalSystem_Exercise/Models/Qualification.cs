using System;
using System.Collections.Generic;

namespace JobPortalSystem_Exercise.Models;

public partial class Qualification
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string? Title { get; set; }

    public string? Mark { get; set; }

    public string? YearOfPassout { get; set; }

    public string? University { get; set; }

    public string? Status { get; set; }

    public virtual User User { get; set; } = null!;
}
