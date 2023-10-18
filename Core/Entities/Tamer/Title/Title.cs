using Core.Common;
using Core.Validations;

namespace Core.Entities.Tamer.Title
{
    public class Title : BaseEntity
    {
        public int Score { get; set; }
        public string Effect { get; set; }
        public string HowObtained { get; set; }

        public Title(int id, string name, string description, int score, string effect, string howObtained)
        {
            if (id < 0) throw new Exception("Id inválido.");
            ValidateTitle(name, description, score, effect, howObtained);
        }

        public Title(string name, string description, int score, string effect, string howObtained)
        {
            ValidateTitle(name, description, score, effect, howObtained);
        }

        private void ValidateTitle(string name, string description, int score, string effect, string HowObtained)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Nome inválido.");
            DomainException.When(string.IsNullOrEmpty(description), "Descrição inválida.");
            DomainException.When(string.IsNullOrEmpty(HowObtained), "Modo de obtenção inválido.");
        }
    }
}