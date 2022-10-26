using Shard.Shared.Core;
using System.Text.Json.Serialization;

namespace Shard.Api.model
{
    public class StarSystem
    {
        public string Name { get; set; }
        public List<Planet> Planets { get; set; }

        public StarSystem(SystemSpecification systemSpecification)
        {
            Name = systemSpecification.Name;
            Planets = new List<Planet>();
            foreach (PlanetSpecification planetSpecification in systemSpecification.Planets)
            {
                Planets.Add(new Planet(planetSpecification));
            }
        }
        public Planet GetRandPlanet()
        {
            Random r = new Random();
            int rand = r.Next(0, Planets.Count());

            return Planets[rand];
        }
    }
}
