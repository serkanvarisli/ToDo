using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserMail { get; set; }

    public string? UserName { get; set; }

    public string? UserSurname { get; set; }
    [MinLength(8, ErrorMessage = "En az 8 karakter gereklidir.")]
    public string? UserPassword { get; set; }

    public virtual ICollection<List> Lists { get; set; } = new List<List>();
}
