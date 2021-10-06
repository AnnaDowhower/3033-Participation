using System;
using System.Collections.Generic;
using System.Text;

namespace JSON_Pokemon
{
    public class Attributes
    {
        public string height { get; set; }
        public string weight { get; set; }
        public Sprites picture { get; set; }
        public Attributes()
        {
            height = string.Empty;
            weight = string.Empty;
            picture = new Sprites();
        }
        public Attributes(string Height, string Weight, Sprites Picture)
        {
            height = string.Empty;
            weight = string.Empty;
            picture = new Sprites();
        }
    }
}
