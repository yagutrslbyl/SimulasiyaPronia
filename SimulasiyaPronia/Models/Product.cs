using Azure;
using SimulasiyaPronia.Models.Base;
using static System.Net.Mime.MediaTypeNames;

namespace SimulasiyaPronia.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int Rating { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

      
       

    }
}
