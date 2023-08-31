using Core.Common;
using Core.Entities.Intermediate;
using Core.Enums;
using Core.Validations;

namespace Core.Entities.Digimon
{
    public sealed class Digimon : CharacterEntity
    {
        public Digimon() { }

        public Digimon(string name, string description, int hp, int ds, int de, int at, float attackSpeed,
        string ct, int ht, string ev, Form form, DigimonAttribute attribute, ElementalAttribute elementalAttribute, bool canBeRiding)
        {
            ValidateDigimon(name, description, hp, ds, de, at, attackSpeed, ct, ht, ev, form, attribute, elementalAttribute, canBeRiding);
        }

        public Digimon(int id, string name, string description, int hp, int ds, int de, int at, float attackSpeed,
        string ct, int ht, string ev, Form form, DigimonAttribute attribute, ElementalAttribute elementalAttribute, bool canBeRiding)
        {
            DomainException.When(id < 0, "Valor de id inválido.");
            Id = id;
            ValidateDigimon(name, description, hp, ds, de, at, attackSpeed, ct, ht, ev, form, attribute, elementalAttribute, canBeRiding);
        }

        public float AS { get; set; }
        public string CT { get; set; }
        public int HT { get; set; }
        public string EV { get; set; }
        public Form Form { get; set; }
        public bool CanBeRiding { get; set; }
        public DigimonAttribute Attribute { get; set; }
        public ElementalAttribute ElementalAttribute { get; set; }
        public ICollection<Digimon> Evolutions { get; set; }
        public ICollection<DigimonFamilyIntermediate> Families { get; set; }
        public ICollection<DigimonSkill> Skills { get; set; }
        public ICollection<DigimonRidingIntermediate> Ridings { get; set; }
        public ICollection<DigimonEvolutionItemIntermediate> EvolutionItens { get; set; }

        private void ValidateDigimon(string name, string description, int hp, int ds, int de, int at, float attackSpeed,
        string ct, int ht, string ev, Form form, DigimonAttribute attribute, ElementalAttribute elementalAttribute, bool canBeRiding)
        {
            DomainException.When(String.IsNullOrEmpty(name), "Nome inválido.");

            DomainException.When(String.IsNullOrEmpty(description), "Descrição inválido.");

            DomainException.When(hp < 0, "HP inválido.");

            DomainException.When(ds < 0, "DS inválido.");

            DomainException.When(de < 0, "DE inválido.");

            DomainException.When(at < 0, "AT inválido.");

            DomainException.When(attackSpeed < 0, "AS inválido.");

            DomainException.When(String.IsNullOrWhiteSpace(ct), "CT inválido.");

            DomainException.When(ht < 0, "HT inválido.");

            DomainException.When(String.IsNullOrEmpty(ev), "EV inválido");

            HP = hp;
            DS = ds;
            DE = de;
            AT = at;
            CT = ct;
            HT = ht;
            EV = ev;
            Name = name;
            Form = form;
            AS = attackSpeed;
            Attribute = attribute;
            Description = description;
            CanBeRiding = canBeRiding;
            ElementalAttribute = elementalAttribute;
        }
    }
}

