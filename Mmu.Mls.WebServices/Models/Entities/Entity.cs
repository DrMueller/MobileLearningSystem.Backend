using Newtonsoft.Json;

namespace Mmu.Mls.WebServices.Models.Entities
{
    public abstract class Entity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        public string TypeName => GetType().Name;
    }
}