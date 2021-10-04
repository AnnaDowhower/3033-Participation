using System;
using System.Collections.Generic;
using System.Text;

namespace JSON_ChuckNorris
{
    public class Result
    {
        public string Joke { get; set; }

        public Result()
        {
            Joke = string.Empty;
        }
        public Result(string joke)
        {
            Joke = joke;
        }
    }
}
