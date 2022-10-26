using Shard.Shared.Core;

namespace Shard.Api.model
{
    public class UnitLocation
    {

        public string system { get; set; }
        public string planet{ get; set; }

        public IReadOnlyDictionary<Resource, int> resourcesQuantity { get; }

        public UnitLocation(string system, string planet, IReadOnlyDictionary<ResourceKind, int> rQ)
        {
            this.system = system;
            this.planet = planet;
            resourcesQuantity = rQ.ToDictionary(ressource => (Resource)ressource.Key, resource => resource.Value);
        }   
    }
}
