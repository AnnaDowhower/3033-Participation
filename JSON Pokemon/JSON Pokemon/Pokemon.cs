using System;
using System.Collections.Generic;
using System.Text;

namespace JSON_Pokemon
{
    public class Pokemon
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<Results> results {get; set;}

        public Pokemon()
        {
            count = 0;
            next = string.Empty;
            previous = string.Empty;
            results = new List<Results>();
        }
        public Pokemon(List<Results> Result)
        {
            count = 0;
            next = string.Empty;
            previous = string.Empty;
            results = Result;
        }
    }
}
