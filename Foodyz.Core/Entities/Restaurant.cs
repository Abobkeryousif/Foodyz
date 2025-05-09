using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodyz.Core.Entities
{
    

    public class Restaurant
    {
        public Restaurant()
        {
            
        }
        public Restaurant(string name, string city, string address, string phone, int categoryId)
        {
            Name = name;
            City = city;
            Address = address;
            Phone = phone;
            CategoryId = categoryId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
         public List<Product> products { get; set; }
        
    }

}
