using System;
using System.Collections.Generic;
using System.Text;

namespace Contact_List
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public Contact()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Photo = string.Empty;
        }
        public Contact(string line)
        {
            var pieces = line.Split('|');

            Id = Convert.ToInt32(pieces[0]);
            FirstName = pieces[1];
            LastName = pieces[2];
            Email = pieces[3];
            Photo = pieces[4];
        }

        public override string ToString()
        {
            return $"{ LastName}, { FirstName}";
        }
    }
}
