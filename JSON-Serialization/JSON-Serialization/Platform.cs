using System;
using System.Collections.Generic;
using System.Text;

namespace JSON_Serialization
{
    public class Platform
    {
        public string Name { get; set; }
        public string platform { get; set; }
        public string ReleaseDate { get; set; }
        public string Summary{ get; set; }
        public string MetaScore{ get; set; }
        public string UserReview { get; set; }

        public Platform()
        {
            Name = string.Empty;
            platform = string.Empty;
            ReleaseDate = string.Empty;
            Summary = string.Empty;
            MetaScore = string.Empty;
            UserReview = string.Empty;
        }
        public Platform(string lines)
        {
            var pieces = lines.Split(',');

            Name = pieces[0];
            platform = pieces[1];
            ReleaseDate = pieces[2];
            Summary = pieces[3];
            MetaScore = pieces[4];
            UserReview = pieces[5];
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
