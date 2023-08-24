using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Digimon;
using Core.Interfaces;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories
{
    public class DigimonSkillRepository : RepositoryBase<DigimonSkill>, IDigimonSkillRepository
    {
        public DigimonSkillRepository(ApplicationDbContext context) : base(context)
        { }
    }
}