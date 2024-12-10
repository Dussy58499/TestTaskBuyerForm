using Repository.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBuyerFormService
    {
        Task<IEnumerable<BuyerForm>> GetAllBuyerFormsAsync();
        Task AddBuyerFormAsync(BuyerForm buyerForm);
    }
}
