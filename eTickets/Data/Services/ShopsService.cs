using eTickets.Data.Base;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ShopsService: EntityBaseRepository<Shop>, IShopsService
    {
        public ShopsService(AppDbContext context) : base(context)
        {
        }
    }
}
