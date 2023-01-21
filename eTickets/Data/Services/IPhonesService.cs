using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IPhonesService : IEntityBaseRepository<Phone>
    {
        Task<Phone> GetMovieByIdAsync(int id);
        Task<NewPhoneDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewPhoneVM data);
        Task UpdateMovieAsync(NewPhoneVM data);
    }
}
