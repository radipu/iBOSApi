using iBOSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBOSApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<iBOS>> Get();
        Task<iBOS> Get(int id);
        Task<iBOS> Create(iBOS product);
        Task Update(iBOS product);
        Task Delete(int id);
    }
}
