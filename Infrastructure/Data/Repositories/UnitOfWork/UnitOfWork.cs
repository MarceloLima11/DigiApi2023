using Core.Interfaces.DigimonManagement;
using Core.Interfaces.TamerManagement;
using Core.Interfaces.UnitOfWork;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.DigimonManagement;
using Infrastructure.Data.Repositories.TamerManagement;

namespace Infrastructure.Data.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected ApplicationDbContext context;

        private TamerRepository tamerRepository;
        private TamerSkillRepository tamerSkillRepository;
        private TamerSkillBuffRepository tamerSkillBuffRepository;
        private DigimonFamilyRepository digimonFamilyRepository;
        private DigimonRepository digimonRepository;
        private DigimonSkillBuffRepository digimonSkillBuffRepository;
        private DigimonSkillRepository digimonSkillRepository;
        private FamilyRepository familyRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }


        public ITamerRepository TamerRepository
        {
            get
            {
                if (tamerRepository == null) return new TamerRepository(context);
                return tamerRepository;
            }
        }

        public ITamerSkillRepository TamerSkillRepository
        {
            get
            {
                if (tamerSkillRepository == null) return new TamerSkillRepository(context);
                return tamerSkillRepository;
            }
        }

        public ITamerSkillBuffRepository TamerSkillBuffRepository
        {
            get
            {
                if (tamerSkillBuffRepository == null) return new TamerSkillBuffRepository(context);
                return tamerSkillBuffRepository;
            }
        }

        public IDigimonFamilyRepository DigimonFamilyRepository
        {
            get
            {
                if (digimonFamilyRepository == null) return new DigimonFamilyRepository(context);
                return digimonFamilyRepository;
            }
        }

        public IDigimonRepository DigimonRepository
        {
            get
            {
                if (digimonRepository == null) return new DigimonRepository(context);
                return digimonRepository;
            }
        }

        public IDigimonSkillRepository DigimonSkillRepository
        {
            get
            {
                if (digimonSkillRepository == null) return new DigimonSkillRepository(context);
                return digimonSkillRepository;
            }
        }

        public IDigimonSkillBuffRepository DigimonSkillBuffRepository
        {
            get
            {
                if (digimonSkillBuffRepository == null) return new DigimonSkillBuffRepository(context);
                return digimonSkillBuffRepository;
            }
        }

        public IFamilyRepository FamilyRepository
        {
            get
            {
                if (familyRepository == null) return new FamilyRepository(context);
                return familyRepository;
            }
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }
    }
}