using Microsoft.Extensions.Configuration;
using MusicShop.DataLayer.Models;
using MusicShop.ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
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


        public async Task<bool> AddItemToCart(AddToCartDto addToCartDto)
        {
            int count = 0;
            string query = @$"EXEC  [dbo].[AddToCart]
                            @customer_id,
		                    @instrument_id,
		                    @amount,
		                    @discount";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@customer_id", SqlDbType.Int);
                command.Parameters["@customer_id"].Value = addToCartDto.CustomerId;

                command.Parameters.Add("@instrument_id", SqlDbType.Int);
                command.Parameters["@instrument_id"].Value = addToCartDto.ItemId;

                command.Parameters.Add("@amount", SqlDbType.Int);
                command.Parameters["@amount"].Value = addToCartDto.Amount;

                command.Parameters.Add("@discount", SqlDbType.Int);
                command.Parameters["@discount"].Value = addToCartDto.Discount;

                count = await command.ExecuteNonQueryAsync();
            }
            return count > 0;
        }

        public async Task<IEnumerable<CartItemDto>> GetCartItems()
        {
            List<CartItemDto> items = new List<CartItemDto>();
            string query = "SELECT Purchase.customer_id, Purchased_Item.instrument_id, " +
                            "Instrument.name, Purchased_Item.amount, Purchased_Item.discount " +
                            "FROM Purchase, Purchased_Item, Instrument " +
                            "WHERE Purchase.finished = 0 " +
                            "AND Purchase.id = Purchased_Item.purchase_id " +
                            "AND Purchased_Item.instrument_id = Instrument.id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        items.Add(new CartItemDto
                        {
                            CustomerId = (int)reader[0],
                            ItemId = (int)reader[1],
                            ItemName = (string)reader[2],
                            Amount = (int)reader[3],
                            Discount = (int)reader[4]
                        }); 
                    }
                }
            }
            return items;
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> FinishPurchase(int customerId)
        {
            int count = 0;
            string query = @$"EXEC  [dbo].[Sell]
                            @customer_id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@customer_id", SqlDbType.Int);
                command.Parameters["@customer_id"].Value = customerId;
                count = await command.ExecuteNonQueryAsync();
            }
            return count > 0;
        }
    }
}
