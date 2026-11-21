namespace MVCWebASPCore.DTOs
{
    public class InvoiceCreateDto
    {
        public DateOnly? Date { get; set; }

        public int IdClient { get; set; }

        //representa la lista de productos que se van a agregar a la factura
        public List<DetailInvoiceDto> Products { get; set; }
            = new List<DetailInvoiceDto>();
    }
}