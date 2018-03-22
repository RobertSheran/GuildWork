using DVDDatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDWebAPI.Models
{
    public class DvdViewModel
    {
        public int DvdId { get; set; }
        public int RealeaseYear { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public string Rating { get; set; }
        public string Director { get; set; }

        public DVD ToDvd()
        {
            return new DVD
            {
                DVDId = DvdId,
                DVDTitle = Title,
                Director = Director,
                DVDNotes = Notes,
                Rating = Rating,
                RealeaseYear = RealeaseYear
            };
        }

        public static DvdViewModel FromDvd(DVD dvd)
        {
            return new DvdViewModel
            {
                DvdId = dvd.DVDId,
                Director = dvd.Director,
                Notes = dvd.DVDNotes,
                Rating = dvd.Rating,
                RealeaseYear = dvd.RealeaseYear,
                Title = dvd.DVDTitle

            };
        }
    }
}