namespace Vimenpaq.Core.Application.DTOs.Orders
{
    public class OrderRequest
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public List<string> Packages { get; set; }
    }
}
