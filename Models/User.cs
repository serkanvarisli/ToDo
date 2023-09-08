using System;
using System.Collections.Generic;

namespace ToDo.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserMail { get; set; }

    public string? UserName { get; set; }

    public string? UserSurname { get; set; }

    public string? UserPassword { get; set; }

    public virtual ICollection<List> Lists { get; set; } = new List<List>();
}
