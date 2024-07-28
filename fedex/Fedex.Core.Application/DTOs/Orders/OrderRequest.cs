namespace Fedex.Core.Application.DTOs.Order
{
    public class OrderRequest
    {
        public string ContactAddress { get; set; }
        public string WarehouseAddress { get; set; }
        public List<string> PackageDimensions { get; set; }
    }
}
