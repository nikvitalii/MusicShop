using Microsoft.Extensions.Configuration;
using MusicShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private string _connectionString { get; }
        public CustomerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("default");
        }
        public async Task<IEnumerable<TopCustomer>> GetTopCustomers()
        {
            List<TopCustomer> topCustomers = new List<TopCustomer>();
            string query = "SELECT * FROM TopCustomersWithNames()";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = await command.ExecuteReaderAsync()) 
                {
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
                }
            }
            return topCustomers;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string query = "SELECT * FROM Customer";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        customers.Add(new Customer
                        {
                            Id = Convert.ToInt32(reader[0]),
                            FirstName = (string)reader[1],
                            SecondName = (string)reader[2],
                            PhoneNumber = (string)reader[3],
                            EMail = (string)reader[4],
                            RegistrationDate = (DateTime)reader[5]
                        });
                    }
                }
            }
            return customers;
        }
    }
}
