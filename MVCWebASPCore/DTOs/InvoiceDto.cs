using MVCWebASPCore.DTOs;

namespace MVCWebASPCore.DTOs
{

    public class InvoiceDto
    {
        public int Id { get; set; }

        public DateOnly? Date { get; set; }

        public string? NameClient { get; set; }

        public decimal Total { get; set; }
        //refers to the list of products associated with the invoice
        public List<DetailInvoiceDto> Products { get; set; }
            = new List<DetailInvoiceDto>();
    }
}
