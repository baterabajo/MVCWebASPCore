using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCWebASPCore.Data.Model;

public partial class TbClient
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]

    public string? Name { get; set; }

    //relación uno a muchos (1:N), 1: Un cliente (TbClient). N: Muchas facturas (TbInvoce).
    public virtual ICollection<TbInvoce> TbInvoces { get; set; } = new List<TbInvoce>();
}
