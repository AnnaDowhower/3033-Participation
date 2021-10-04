using System;
using System.Collections.Generic;
using System.Text;

namespace Exam1Practice
{
    public class Show
    {
        public string Actors { get; set; }
        public string Awards { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string RuntimeInMinutes { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Writer { get; set; }
        public string Year { get; set; }
        public string ImdbID { get; set; }
        public string ImdbRating { get; set; }
        public string ImdbVotes { get; set; }
        public string TotalSeasons { get; set; }

        public Show()
        {
            Actors = string.Empty;
            Awards = string.Empty;
            Country = string.Empty;
            Director = string.Empty;
            Genre = string.Empty;
            Language = string.Empty;
            Plot = string.Empty;
            Poster = string.Empty;
            Rated = string.Empty;
            Released = string.Empty;
            RuntimeInMinutes = string.Empty;
            Title = string.Empty;
            Type = string.Empty;
            Writer = string.Empty;
            Year = string.Empty;
            ImdbID = string.Empty;
            ImdbRating = string.Empty;
            ImdbVotes = string.Empty;
            TotalSeasons = string.Empty;
        }
        public Show(string lines)
        {
            var peices = lines.Split('\t');

            Actors = peices[1];
            Awards = peices[2];
            Country = peices[3];
            Director = peices[4];
            Genre = peices[5];
            Language = peices[6];
            Plot = peices[7];
            Poster = peices[8];
            Rated = peices[9];
            Released = peices[10];
            RuntimeInMinutes = peices[11];
            Title = peices[12];
            Type = peices[13];
            Writer = peices[14];
            Year = peices[15];
            ImdbID = peices[16];
            ImdbRating = peices[17];
            ImdbVotes = peices[18];
            TotalSeasons = peices[19];
        }
        public override string ToString()
        {
            return $"{Title} rated {Rated} created in {Country} in {Language} language(s)";
        }
    }
}
