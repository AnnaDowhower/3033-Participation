using System;
using System.Collections.Generic;
using System.Text;

namespace JSON_ChuckNorris
{
    public class Result
    {
        public List<string> categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }

        public Result()
        {
            categories = new List<string>();
            created_at = string.Empty;
            icon_url = string.Empty;
            id = string.Empty;
            updated_at = string.Empty;
            url = string.Empty;
            value = string.Empty;
        }
        public Result(string Value)
        {
            categories = new List<string>();
            created_at = string.Empty;
            icon_url = string.Empty;
            id = string.Empty;
            updated_at = string.Empty;
            url = string.Empty;
            value = Value;
        }
    }
}
