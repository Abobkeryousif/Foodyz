using Foodyz.Application.Contracts.Interfaces;
using Foodyz.Core.Entities;
using Foodyz.Infrastructure.Data;


namespace Foodyz.Infrastructure.Implemention
{
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
