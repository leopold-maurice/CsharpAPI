using Shard.Shared.Core;
using System.Text.Json.Serialization;

namespace Shard.Api.model
{
    public class Planet
    {
        public string Name { get; set; }
        public int Size { get; set; }

        [JsonConstructor]
        public Planet(PlanetSpecification planetSpecification)
        {
            Name = planetSpecification.Name;
            Size = planetSpecification.Size;
        }
    }
}
