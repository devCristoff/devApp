namespace Vimenpaq.Core.Application.DTOs.Orders
{
    public class OrderRequest
    {
        public string Consigee { get; set; }
        public string Consignor { get; set; }
        public List<string> Cartons { get; set; }
    }
}
