using Shard.Shared.Core;
using System.Text.Json.Serialization;

namespace Shard.Api.model
{
    public class Unit
    {
        public string id { get; set; }
        public string type { get; set; }
        public string system { get; set; }
        public string? planet { get; set; }
        public string? destinationSystem { get; set; }
        public string? destinationPlanet { get; set; }
        public string? estimatedTimeOfArrival { get; }

        [JsonIgnore]
        public UnitLocation? location { get; set; }

        public Unit(string id, string type, string system, string? planet, IReadOnlyDictionary<ResourceKind, int> rQ)
        {
            this.id = id;
            this.type = type;
            this.system = system;
            this.planet = planet;

            this.location = new UnitLocation(system, planet, rQ);
        }
        [JsonConstructor]
        public Unit(string id, string type, string system, string? planet)
        {
            this.id = id;
            this.type = type;
            this.system = system;
            this.planet = planet;
        }

        public void ChangeDestination(string s, string? p)
        {
            system = s;
            location.system = s;
            if(p != null)
            {
                planet = p;
                location.planet = p;
            }
        }
    }
}
