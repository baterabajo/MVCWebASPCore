namespace MVCWebASPCore.DTOs
{
    public class DetailInvoiceDto
    {
        public int IdProduct { get; set; }

        public string? NameProduct { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}