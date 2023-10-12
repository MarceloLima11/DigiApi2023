using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("seal")]
    public class SealService
    {
        private readonly ISealService _sealService;

        public SealService(ISealService sealService)
        { _sealService = sealService; }


    }
}