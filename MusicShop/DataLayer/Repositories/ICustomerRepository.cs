using Microsoft.Extensions.Configuration;
using MusicShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public Task<IEnumerable<TopCustomer>> GetTopCustomers();
    }
}
