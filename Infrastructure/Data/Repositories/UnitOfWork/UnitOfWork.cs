using Core.Interfaces.UnitOfWork;
using Infrastructure.Data.Context;
using Core.Interfaces.TamerManagement;
using Core.Interfaces.DigimonManagement;
using Infrastructure.Data.Repositories.ItemManagement;
using Infrastructure.Data.Repositories.TamerManagement;
using Infrastructure.Data.Repositories.DigimonManagement;
using Core.Interfaces.ItemManagement;
using Core.Interfaces.Auth;
using Infrastructure.Data.Repositories.AuthManagement;

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
        private ItemRepository itemRepository;
        private ItemTypeRepository itemTypeRepository;
        private IDigimonItemRepository digimonItemRepository;
        private IUserRepository userRepository;
        private IEmailConfirmationRepository emailConfirmationRepository;

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

        public IItemRepository ItemRepository
        {
            get
            {
                if (itemRepository == null) return new ItemRepository(context);
                return itemRepository;
            }
        }

        public IItemTypeRepository ItemTypeRepository
        {
            get
            {
                if (itemTypeRepository == null) return new ItemTypeRepository(context);
                return itemTypeRepository;
            }
        }

        public IDigimonItemRepository DigimonItemRepository
        {
            get
            {
                if (digimonItemRepository == null) return new DigimonItemRepository(context);
                return digimonItemRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null) return new UserRepository(context);
                return userRepository;
            }
        }

        public IEmailConfirmationRepository EmailConfirmationRepository
        {
            get
            {
                if (emailConfirmationRepository == null) return new EmailConfirmationRepository(context);
                return emailConfirmationRepository;
            }
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }
    }
}