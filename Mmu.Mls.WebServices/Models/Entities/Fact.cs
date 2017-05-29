using Mmu.Mls.WebServices.Models.ValueObjects;

namespace Mmu.Mls.WebServices.Models.Entities
{
    public class Fact : Entity
    {
        public Fact()
        {
            Question = new Question();
            Answer = new Answer();
        }

        public Answer Answer { get; set; }

        public string Name { get; set; }

        public Question Question { get; set; }
    }
}