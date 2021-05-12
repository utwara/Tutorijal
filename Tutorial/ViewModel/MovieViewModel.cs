using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tutorial.ViewModel
{
    public class MovieViewModel
    {
        [Key]
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string MovieYear { get; set; }
        public string MovieAbbrevation { get; set; }
       
    }
}
