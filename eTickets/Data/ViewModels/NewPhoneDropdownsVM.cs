using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels
{
    public class NewPhoneDropdownsVM
    {
        public NewPhoneDropdownsVM()
        {
            Shops = new List<Shop>();
            Categories = new List<Category>();
        }

        public List<Shop> Shops { get; set; }
        public List<Category> Categories { get; set; }
    }
}
