using Application.Interfaces;
using Core.Interfaces.UnitOfWork;

namespace Application.Services
{
    public class SealService : ISealService
    {
        private readonly IUnitOfWork _unit;

        public SealService(IUnitOfWork unit)
        { _unit = unit; }
    }
}