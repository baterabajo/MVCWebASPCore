using System;
using System.Collections.Generic;

namespace MVCWebASPCore.Data.Model;

public partial class TbInvoce
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public int? IdClient { get; set; }

    public decimal? Total { get; set; }

    //Muchos a Uno (N:1): muchas facturas pueden pertenecer a un mismo cliente.
    public virtual TbClient? IdClientNavigation { get; set; }

    //relación uno a muchos (1:N), 1: Una factura (TbInvoce). N: Muchos detalles (TbDetailInvoce).
    public virtual ICollection<TbDetailInvoce> TbDetailInvoces { get; set; } = new List<TbDetailInvoce>();
}
