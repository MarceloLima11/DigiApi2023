using Core.Enums;
using Core.Entities.Digimon;
using Application.Interfaces;
using Core.Entities.Digimon.Buff;
using Core.Interfaces.UnitOfWork;
using Core.Entities.Intermediate;
using Application.DTOs.DigimonManagement;
using Core.Entities.Item;
using Core.Entities.Item.Category;
using Application.DTOs.Shared;

namespace Application.Services
{
    public class DigimonService : IDigimonService
    {
        protected readonly IUnitOfWork _unit;

        public DigimonService(IUnitOfWork unit)
        { _unit = unit; }

        public async Task<IEnumerable<DigimonDTO>> GetDigimons()
        {
            try
            {
                var digimonsDTO = new List<DigimonDTO>();
                var digimons = await _unit.DigimonRepository.GetAll();

                foreach (Digimon digimon in digimons)
                {
                    DigimonSkill skill = await _unit.DigimonSkillRepository.GetSkillByDigimon(digimon.Id);
                    DigimonBuffDTO buffDTO = null;
                    DigimonSkillBuff buff = null;
                    if (skill.DigimonSkillBuffId != null)
                    {
                        buff = await _unit.DigimonSkillBuffRepository.GetById((int)skill.DigimonSkillBuffId);

                        buffDTO = new DigimonBuffDTO()
                        {
                            Name = buff.Name,
                            Description = buff.Description,
                            ActivationPercentage = buff.ActivationPercentage
                        };
                    }

                    var skillDTO = new DigimonSkillDTO()
                    {
                        Name = skill.Name,
                        Description = skill.Description,
                        AnimationTime = skill.AnimationTime,
                        Attribute = skill.Attribute,
                        CoolDown = skill.CoolDown,
                        DSConsumed = skill.DSConsumed,
                        NecessarySkillPoint = skill.NecessarySkillPoint,
                        Buff = buffDTO
                    };

                    var familiesDTO = new List<FamilyDTO>();
                    var digimonFamiliesIntermediate = await _unit.DigimonFamilyRepository.GetDigimonFamilyIntermediatesByDigimon(digimon.Id);
                    foreach (var intermediate in digimonFamiliesIntermediate)
                    {
                        Family family = await _unit.FamilyRepository.GetById(intermediate.FamilyId);

                        familiesDTO.Add(new FamilyDTO
                        {
                            Name = family.Name,
                            Description = family.Description,
                            Abbreviation = family.Abbreviation
                        });
                    }

                    DigimonDTO digimonDTO = new()
                    {
                        Id = digimon.Id,
                        Name = digimon.Name,
                        Description = digimon.Description,
                        AS = digimon.AS,
                        AT = digimon.AT,
                        Attribute = digimon.Attribute,
                        CT = digimon.CT,
                        DE = digimon.DE,
                        DS = digimon.DS,
                        ElementalAttribute = digimon.ElementalAttribute,
                        EV = digimon.EV,
                        Form = digimon.Form,
                        HP = digimon.HP,
                        HT = digimon.HT,
                        Skill = skillDTO,
                        Families = familiesDTO
                    };

                    List<ItemDTO> itemDTOs = new();
                    var digimonItemIntermediates = await _unit.DigimonItemRepository.GetDigimonItemIntermediatesByDigimon(digimon.Id);
                    foreach (var digimonItem in digimonItemIntermediates)
                    {
                        Item item = await _unit.ItemRepository.GetById(digimonItem.ItemId);
                        ItemType itemType = await _unit.ItemTypeRepository.GetById(item.ItemTypeId);

                        itemDTOs.Add(new ItemDTO()
                        {
                            Name = item.Name,
                            Description = item.Description,
                            Type = itemType.Description,
                            Quantity = digimonItem.Quantity
                        });

                        digimonDTO.Itens = itemDTOs;
                    }

                    digimonsDTO.Add(digimonDTO);
                }

                return digimonsDTO;
            }
            catch
            { throw; }
        }

        public async Task<DigimonDTO> GetDigimon(int id)
        {
            try
            {
                var digimon = await _unit.DigimonRepository.GetById(id)
                    ?? throw new NullReferenceException("Digimon não encontrado.");

                DigimonSkill skill = await _unit.DigimonSkillRepository.GetSkillByDigimon(id);
                DigimonBuffDTO buffDTO = null;
                DigimonSkillBuff buff = null;
                if (skill.DigimonSkillBuffId != null)
                {
                    buff = await _unit.DigimonSkillBuffRepository.GetById((int)skill.DigimonSkillBuffId);

                    buffDTO = new DigimonBuffDTO()
                    {
                        Name = buff.Name,
                        Description = buff.Description,
                        ActivationPercentage = buff.ActivationPercentage
                    };
                }

                var skillDTO = new DigimonSkillDTO()
                {
                    Name = skill.Name,
                    Description = skill.Description,
                    AnimationTime = skill.AnimationTime,
                    Attribute = skill.Attribute,
                    CoolDown = skill.CoolDown,
                    DSConsumed = skill.DSConsumed,
                    NecessarySkillPoint = skill.NecessarySkillPoint,
                    Buff = buffDTO
                };

                var familiesDTO = new List<FamilyDTO>();
                var digimonFamiliesIntermediate = await _unit.DigimonFamilyRepository.GetDigimonFamilyIntermediatesByDigimon(id);
                foreach (var intermediate in digimonFamiliesIntermediate)
                {
                    Family family = await _unit.FamilyRepository.GetById(intermediate.FamilyId);

                    familiesDTO.Add(new FamilyDTO
                    {
                        Name = family.Name,
                        Description = family.Description,
                        Abbreviation = family.Abbreviation
                    });
                }

                DigimonDTO digimonDTO = new()
                {
                    Id = digimon.Id,
                    Name = digimon.Name,
                    Description = digimon.Description,
                    AS = digimon.AS,
                    AT = digimon.AT,
                    Attribute = digimon.Attribute,
                    CT = digimon.CT,
                    DE = digimon.DE,
                    DS = digimon.DS,
                    ElementalAttribute = digimon.ElementalAttribute,
                    EV = digimon.EV,
                    Form = digimon.Form,
                    HP = digimon.HP,
                    HT = digimon.HT,
                    Skill = skillDTO,
                    Families = familiesDTO
                };

                List<ItemDTO> itemDTOs = new();
                var digimonItemIntermediates = await _unit.DigimonItemRepository.GetDigimonItemIntermediatesByDigimon(id);
                foreach (var digimonItem in digimonItemIntermediates)
                {
                    Item item = await _unit.ItemRepository.GetById(digimonItem.ItemId);
                    ItemType itemType = await _unit.ItemTypeRepository.GetById(item.ItemTypeId);

                    itemDTOs.Add(new ItemDTO()
                    {
                        Name = item.Name,
                        Description = item.Description,
                        Type = itemType.Description,
                        Quantity = digimonItem.Quantity
                    });

                    digimonDTO.Itens = itemDTOs;
                }

                return digimonDTO;
            }
            catch
            { throw; }
        }

        public async Task<string> CreateDigimon(CreateDigimonDTO digimonDTO)
        {
            try
            {
                if (digimonDTO is null || digimonDTO.Skill is null)
                    throw new Exception("Digimon inválido.");

                foreach (int familyId in digimonDTO.Families)
                {
                    if (!Enum.IsDefined(typeof(FamilyEnum), familyId))
                        throw new Exception("Família de Digimon inválida.");
                }

                DigimonSkillBuff buff = null;
                DigimonBuffDTO buffDTO = null;
                if (digimonDTO.Skill.Buff != null)
                {
                    buffDTO = digimonDTO.Skill.Buff;
                    buff = new(buffDTO.Name, buffDTO.Description, buffDTO.ActivationPercentage);
                    _unit.DigimonSkillBuffRepository.Add(buff);
                    await _unit.Commit();
                }

                Digimon digimon = new(digimonDTO.Name, digimonDTO.Description, digimonDTO.HP, digimonDTO.DS, digimonDTO.DE, digimonDTO.AT, digimonDTO.AS, digimonDTO.CT, digimonDTO.HT, digimonDTO.EV, digimonDTO.Form, digimonDTO.Attribute, digimonDTO.ElementalAttribute, digimonDTO.CanBeRiding);
                _unit.DigimonRepository.Add(digimon);
                await _unit.Commit();

                DigimonSkillDTO skillDTO = digimonDTO.Skill;
                DigimonSkill skill = new(skillDTO.Name, skillDTO.Description, skillDTO.Attribute, skillDTO.CoolDown, skillDTO.DSConsumed,
                skillDTO.NecessarySkillPoint, skillDTO.AnimationTime, digimon.Id, buff.Id);
                _unit.DigimonSkillRepository.Add(skill);
                await _unit.Commit();

                foreach (int familyId in digimonDTO.Families)
                {
                    var intermediate = new DigimonFamilyIntermediate()
                    {
                        DigimonId = digimon.Id,
                        FamilyId = familyId
                    };
                    _unit.DigimonFamilyRepository.Add(intermediate);
                    await _unit.Commit();
                }

                foreach (EntityIdValue item in digimonDTO.Itens)
                {
                    var intermediate = new DigimonItemIntermediate()
                    {
                        DigimonId = digimon.Id,
                        ItemId = item.Id,
                        Quantity = item.Value
                    };
                    _unit.DigimonItemRepository.Add(intermediate);
                    await _unit.Commit();
                }
                return "Sucesso!";
            }
            catch
            { throw; }
        }
    }
}