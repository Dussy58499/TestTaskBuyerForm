using Repository.Interfaces;
using Repository.Models.Domain;
using Repository.Repository;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BuyerFormService : IBuyerFormService
    {
        private readonly IBuyerFormRepository _buyerFormRepository;
        
        public BuyerFormService(IBuyerFormRepository buyerFormRepository)
        {
            _buyerFormRepository = buyerFormRepository;
        }

        public async Task<IEnumerable<BuyerForm>> GetAllBuyerFormsAsync()
        {
            try
            {
                return await _buyerFormRepository.GetAllAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception("An error while fetching buyer forms", ex);
            }
        }
        
        public async Task AddBuyerFormAsync(BuyerForm buyerForm)
        {
            try
            {
                await _buyerFormRepository.AddAsync(buyerForm);
                await _buyerFormRepository.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception("An error while adding the buyer form", ex);
            }
        }
    }
}
