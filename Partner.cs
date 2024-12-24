using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinFormsApp1;

public class Partner
{
    public int Id { get; set; }

    [ForeignKey("IdTypeOfPartner")]
    public int IdTypeOfPartner { get; set; }

    [Required]
    [StringLength(50)]
    public string NameOfPartner { get; set; }

    [Required]
    [StringLength(1000)]
    public string LegalAdress { get; set; }

    [Required]
    [StringLength(20)]
    [Column("INN")]
    public string Inn { get; set; }

    [Required]
    [StringLength(100)]
    public string FullNameOfDirector { get; set; }

    [Required]
    [StringLength(20)]
    public string Phone { get; set; }

    [Required]
    [StringLength(40)]
    public string Email { get; set; }

    public short Rating { get; set; }

    public virtual TypesOfPartner IdTypeOfPartnerNavigation { get; set; }
    [NotMapped] // Указывает, что это свойство не должно отображаться в базе данных
    public string DisplayName => NameOfPartner;

    public virtual ICollection<PartnersProduction> PartnersProductions { get; set; } = new List<PartnersProduction>();
}