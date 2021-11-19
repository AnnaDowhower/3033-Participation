using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_beginner.Models
{
    public class PokemonInfo
    {
        public int id { get; set; }
        public int height { get; set; }
        public string name { get; set; }
        public int weight { get; set; }
        public Sprite sprites { get; set; }
    }
    public class Sprite
    {
        public string back_default { get; set; }
        public string front_default { get; set; }
    }
}