using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WinFormsApp1;

public class TypesOfProduction
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string TypeOfProduction { get; set; }

    public virtual ICollection<Production> Productions { get; set; } = new List<Production>();
}
