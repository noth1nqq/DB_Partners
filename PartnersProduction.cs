using System;
using System.Collections.Generic;

namespace WinFormsApp1;

public partial class PartnersProduction
{
    public int Id { get; set; }

    public int IdPartner { get; set; }

    public int IdProduction { get; set; }

    public int Quantity { get; set; }

    public DateTime DateOfSale { get; set; }

    public virtual Partner IdPartnerNavigation { get; set; } = null!;

    public virtual Production IdProductionNavigation { get; set; } = null!;
}
