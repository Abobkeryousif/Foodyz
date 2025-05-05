using Foodyz.Application.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodyz.Infrastructure.Implemention
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
    }
}
