using Repository.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IBuyerFormRepository
    {
        Task<IEnumerable<BuyerForm>> GetAllAsync();
        Task AddAsync(BuyerForm entity);
        Task SaveChangesAsync();
    }
}
