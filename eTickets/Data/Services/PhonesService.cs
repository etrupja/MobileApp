using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class PhonesService : EntityBaseRepository<Phone>, IPhonesService
    {
        private readonly AppDbContext _context;
        public PhonesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewPhoneVM data)
        {
            var newMovie = new Phone()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CategoryId = data.CategoryId,
                ShopId = data.ShopId
            };
            await _context.Phones.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            await _context.SaveChangesAsync();
        }

        public async Task<Phone> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Phones
                .Include(c => c.Category)
                .Include(p => p.Shop)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewPhoneDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewPhoneDropdownsVM()
            {
                Categories = await _context.Categories.OrderBy(n => n.Name).ToListAsync(),
                Shops = await _context.Shops.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }

        public async Task UpdateMovieAsync(NewPhoneVM data)
        {
            var dbMovie = await _context.Phones.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.CategoryId = data.CategoryId;
                dbMovie.ShopId = data.ShopId;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            await _context.SaveChangesAsync();
        }
    }
}
