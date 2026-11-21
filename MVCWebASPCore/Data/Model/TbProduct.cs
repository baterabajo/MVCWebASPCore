using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCWebASPCore.Data.Model;

public partial class TbProduct
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")] //using System.ComponentModel.DataAnnotations;
    public string? Name { get; set; }
    [Required(ErrorMessage = "Price is required")]
    public decimal? Price { get; set; }

    //relación uno a muchos (1:N) entre TbInvoce y TbDetailInvoce.1 (Uno): TbInvoce (una factura).
    //N(Muchos) : TbDetailInvoce(muchos detalles de esa factura).
    public virtual ICollection<TbDetailInvoce> TbDetailInvoces { get; set; } = new List<TbDetailInvoce>();
}
