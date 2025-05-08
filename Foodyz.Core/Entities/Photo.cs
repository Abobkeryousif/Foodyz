using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodyz.Core.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string photoPath { get; set; }
        public int ProductId { get; set; }
        public List<Product> Products { get; set; }
    }
}
