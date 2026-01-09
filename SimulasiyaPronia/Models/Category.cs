using SimulasiyaPronia.Models.Base;
using System.Globalization;

namespace SimulasiyaPronia.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
