using System;
using System.Collections.Generic;

namespace ToDo.Models;

public partial class List
{
    public int ListId { get; set; }

    public int? UserId { get; set; }

    public string? Value { get; set; }

    public DateTime? Tarih { get; set; }

    public virtual User? User { get; set; }
}
