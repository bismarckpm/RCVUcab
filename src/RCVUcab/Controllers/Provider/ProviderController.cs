using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Responses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCVUcab.Controllers.Provider
{
    [ApiController]
    [Route("provider")]
    public class ProviderController : Controller
    {
        private readonly IProviderDAO _providerDAO;
        private readonly ILogger<ProviderController> _logger;

        public ProviderController(ILogger<ProviderController> logger, IProviderDAO providerDAO)
        {
            _providerDAO = providerDAO;
            _logger = logger;
        }

        [HttpGet("providers/{brand}")]
        public ApplicationResponse<List<BrandDTO>> GetProvidersByBrand([Required][FromRoute] string brand)
        {
            var response = new ApplicationResponse<List<BrandDTO>>();
            try
            {
                response.Data = _providerDAO.GetProvidersByBrand(brand);
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
    }
}
