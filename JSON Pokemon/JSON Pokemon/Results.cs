using System;
using System.Collections.Generic;
using System.Text;

namespace JSON_Pokemon
{
    public class Results
    {
        public string name { get; set; }
        public string url { get; set; }

        public Results()
        {
            name = string.Empty;
            url = string.Empty;
        }
        public Results(string Name, string URL)
        {
            name = Name;
            url = URL;
        }
        public override string ToString()
        {
            return $"{name}";
        }
    }
}
