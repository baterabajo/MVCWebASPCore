using System;
using System.Collections.Generic;

namespace MVCWebASPCore.Data.Model;

public partial class TbDetailInvoce
{
    public int Id { get; set; }

    public int IdInvoce { get; set; }

    public int IdProduct { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    //Muchos a Uno (N:1): muchos detalles de factura pueden pertenecer a una misma factura.
    public virtual TbInvoce IdInvoceNavigation { get; set; } = null!;
    //Muchos a Uno (N:1): muchos detalles de factura pueden pertenecer a un mismo producto.
    public virtual TbProduct IdProductNavigation { get; set; } = null!;
}
