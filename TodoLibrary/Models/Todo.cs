using System;
using System.Collections.Generic;

namespace TodoLibrary.Models;

public partial class Todo
{
    public int TaskNo { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? DueDate { get; set; }

    public int? Priority { get; set; }

    public string? Status { get; set; }
}
