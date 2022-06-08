using Microsoft.EntityFrameworkCore;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RCVUcab.Persistence.DAOs.Implementations
{
    public class ProviderDAO : IProviderDAO
    {
        public readonly IRCVDbContext _context;

        public ProviderDAO(IRCVDbContext context)
        {
            _context = context;
        }

        public List<BrandDTO> GetProvidersByBrand(string brand)
        {
            try
            {
                var data = _context.Brands
                   .Include(b => b.Providers)
                   .Where(b => b.Name == brand)
                   .Select(b => new BrandDTO
                   {
                       Id = b.Id,
                       Name = b.Name,
                       Providers = b.Providers.Select(p => new ProviderDTO
                       {
                           Id = p.Id,
                           FullName = p.Name + " " + p.LastName,
                           Address = p.Address
                       }).ToList()
                   });

                return data.ToList();
            }
            catch(Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de proveedores para la marca: "
              + brand, ex.Message, ex);
            }
        }
    }
}
