using System;
using System.Collections.Generic;
using System.Text;

namespace JSON_Pokemon
{
    public class Pokemon
    {
        public int count { get; set; }
        public List<Results> results {get; set;}
    }
    public class Results
    {
        public string name { get; set; }
        public string url { get; set; }
        public override string ToString()
        {
            return $"{name}";
        }
    }
}
