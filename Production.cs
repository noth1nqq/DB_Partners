using System;
using System.Collections.Generic;

namespace WinFormsApp1;

public partial class Production
{
    public int Id { get; set; }

    public int IdTypeOfProduction { get; set; }

    public string NameOfProduction { get; set; } = null!;

    public string Article { get; set; } = null!;

    public decimal MinPriceForPartner { get; set; }

    public virtual TypesOfProduction IdTypeOfProductionNavigation { get; set; } = null!;

    public virtual ICollection<PartnersProduction> PartnersProductions { get; set; } = new List<PartnersProduction>();
}
