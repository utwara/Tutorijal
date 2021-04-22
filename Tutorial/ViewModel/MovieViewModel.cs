using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tutorial.ViewModel
{
    public class MovieViewModel
    {
        public string MovieName { get; set; }
        public string MovieYear { get; set; }
        public string MovieAbbrevation { get; set; }
        public int MovieID { get; set; }
    }
}
