using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Category:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Category Logo")]
        [Required(ErrorMessage = "Category logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Category description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Phone> Phones { get; set; }
    }
}
