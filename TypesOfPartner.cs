using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WinFormsApp1;

public class TypesOfPartner
{
    public int Id { get; set; }

    [Required]
    [StringLength(1000)]
    public string TypeOfPartner { get; set; }

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
