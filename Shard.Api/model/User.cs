using Microsoft.AspNetCore.Mvc;
using Shard.Shared.Core;
using System;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Shard.Api.model
{
    public class User
    {
        public string id { get; set; }
        public string? pseudo { get; set; }
        public string? dateOfCreation { get; }

        public IDictionary<Resource, int>? resourcesQuantity { get; set; }

        [JsonIgnore]
        public List<Unit>? units { get; set; }

        [JsonConstructor]
        public User(string id, string? pseudo)
        {
            this.id = id;
            this.pseudo = pseudo;
        }

        public User(string id, string? pseudo, Sector sector)
        {
            StarSystem system = sector.GetRandSys();
            Planet planet = system.GetRandPlanet();
            Random rand = new Random();
            this.id = id;
            this.pseudo = pseudo;
            this.dateOfCreation = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK");
            this.units = new List<Unit> {
                new Unit(rand.NextGuid().ToString(),
                         "scout",
                         system.Name,
                         planet.Name,
                         new RandomShareComputer(rand).GenerateResources(planet.Size))
            };
    }
    }
}
