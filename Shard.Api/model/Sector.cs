using Microsoft.AspNetCore.Mvc;
using Shard.Shared.Core;
using Newtonsoft.Json;

namespace Shard.Api.model
{
    public class Sector
    {
        public List<StarSystem> Systems { get; set; }
        public Sector(MapGenerator mapGenerator)
        {
            var sectorSpecification = mapGenerator.Generate();
            Systems = new List<StarSystem>();
            foreach(SystemSpecification system in sectorSpecification.Systems)
            {
                Systems.Add(new StarSystem(system));
            }
        }

        public StarSystem GetRandSys()
        {
            Random r = new Random();
            int rand = r.Next(0, Systems.Count());
            return Systems[rand];
        }
    }
}
