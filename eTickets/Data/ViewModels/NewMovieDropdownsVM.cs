using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public NewMovieDropdownsVM()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Category>();
            Actors = new List<Actor>();
        }

        public List<Producer> Producers { get; set; }
        public List<Category> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
