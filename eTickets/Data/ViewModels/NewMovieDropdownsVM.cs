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
            Producers = new List<Shop>();
            Cinemas = new List<Category>();
        }

        public List<Shop> Producers { get; set; }
        public List<Category> Cinemas { get; set; }
    }
}
