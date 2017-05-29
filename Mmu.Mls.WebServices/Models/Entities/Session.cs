using System.Collections.Generic;
using Mmu.Mls.WebServices.Models.ValueObjects;

namespace Mmu.Mls.WebServices.Models.Entities
{
    public class Session : Entity
    {
        public string Name { get; set; }

        public ICollection<SessionFact> SessionFacts { get; set; }

        public ICollection<SessionRun> SessionRuns { get; set; }
    }
}