using MusicShop.DataLayer.Models;
using MusicShop.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.ServiceLayer.Services
{
    public interface ICustomerService
    {
        public Task<IEnumerable<TopCustomer>> GetTopCustomers();
        public Task<IEnumerable<Customer>> GetCustomers();
    }
}
