using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IItemsService : IEntityBaseRepository<Item>
    {
        Task<Item> GetMovieByIdAsync(int id);
        Task<NewItemDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewItemVM data);
        Task UpdateMovieAsync(NewItemVM data);
    }
}
