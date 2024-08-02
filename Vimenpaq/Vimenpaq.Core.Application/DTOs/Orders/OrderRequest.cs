using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Vimenpaq.Core.Application.DTOs.Orders
{
    /// <summary>
    /// Parameters to create an order
    /// </summary> 
    [XmlRoot("OrderRequest")]
    public class OrderRequest
    {
        /// <example>C. Porfirio Herrera, Santo Domingo</example>
        [XmlElement("source")]
        public string Source { get; set; }

        /// <example>C2M8+X9R, Av. Gregorio Luperón, Santo Domingo</example>
        [XmlElement("destination")]
        public string Destination { get; set; }

        /// <example><package>10x20x30</package></example>
        [XmlArray("packages")]
        [XmlArrayItem("package")]
        public List<string> Packages { get; set; }
    }
}
