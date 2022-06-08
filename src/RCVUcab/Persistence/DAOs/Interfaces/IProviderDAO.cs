using RCVUcab.BussinesLogic.DTOs;
using System.Collections.Generic;

namespace RCVUcab.Persistence.DAOs.Interfaces
{
    public interface IProviderDAO
    {
        public List<BrandDTO> GetProvidersByBrand(string Brand);
    }
}
