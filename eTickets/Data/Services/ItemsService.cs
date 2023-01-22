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
    public class ItemsService : EntityBaseRepository<Item>, IItemsService
    {
        private readonly AppDbContext _context;
        public ItemsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewItemVM data)
        {
            var newMovie = new Item()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CategoryId = data.CategoryId,
                ShopId = data.ShopId
            };
            await _context.Items.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            await _context.SaveChangesAsync();
        }

        public async Task<Item> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Items
                .Include(c => c.Category)
                .Include(p => p.Shop)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewItemDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewItemDropdownsVM()
            {
                Categories = await _context.Categories.OrderBy(n => n.Name).ToListAsync(),
                Shops = await _context.Shops.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }

        public async Task UpdateMovieAsync(NewItemVM data)
        {
            var dbMovie = await _context.Items.FirstOrDefaultAsync(n => n.Id == data.Id);

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
