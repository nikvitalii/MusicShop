using Microsoft.Extensions.Configuration;
using MusicShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private string _connectionString { get; }
        public ItemRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("default");
        }


        public async Task<IEnumerable<ItemWithProducer>> GetItemWithProducers()
        {
            List<ItemWithProducer> items = new List<ItemWithProducer>();
            string query = "SELECT * FROM GetItemsWithProducers()";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        items.Add(new ItemWithProducer
                        {
                            ItemId = Convert.ToInt32(reader[0]),
                            Item = (string)reader[1],

                            ProducerId = Convert.ToInt32(reader[2]),
                            Producer = (string)reader[3],

                            TypeId = Convert.ToInt32(reader[4]),
                            Type = (string)reader[5],

                            Cost = Convert.ToInt32(reader[6]),
                            Amount = Convert.ToInt32(reader[7])
                        });
                    }
                }
            }
            return items;
        }

        IEnumerable<Item> IItemRepository.GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
