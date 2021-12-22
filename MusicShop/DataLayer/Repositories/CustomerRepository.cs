using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MusicShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private string _connectionString { get; }

        public CustomerRepository(MusicShopDbContext context, IConfiguration configuration):base(context)
        {
            _connectionString = configuration.GetConnectionString("default");
        }
        public async Task<IEnumerable<TopCustomer>> GetTopCustomers()
        {
            List<TopCustomer> topCustomers = new List<TopCustomer>();

            using(var connection = Context.Database.GetDbConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TopCustomersWithNames()";


                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    topCustomers.Add(new TopCustomer
                    {
                        CustomerId = Convert.ToInt32(reader[0]),
                        FirstName = (string)reader[1],
                        SecondName = (string)reader[2],
                        TotalSum = Convert.ToInt32(reader[3])
                    });
                }
                await connection.CloseAsync();
            }

            return topCustomers;
        }
    }
}
