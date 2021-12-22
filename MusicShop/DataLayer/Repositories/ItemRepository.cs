using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MusicShop.DataLayer.Models;
using MusicShop.ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Repositories
{
    public class ItemRepository : Repository<Instrument>, IItemRepository
    {
        private string _connectionString { get; }
        public ItemRepository(MusicShopDbContext context, IConfiguration configuration):base(context)
        {
            _connectionString = configuration.GetConnectionString("default");
        }


        public async Task<IEnumerable<Instrument>> GetItemWithProducers()
        {
            return await Context
                .Instrument
                .Include(instrument => instrument.Instrument_Type)
                .Include(instrument => instrument.Producer)
                .ToListAsync();
        }


        public async Task<bool> AddItemToCart(AddToCartDto addToCartDto)
        {
            int count = 0;
            string query = @$"EXEC  [dbo].[AddToCart]
                            @customer_id,
		                    @instrument_id,
		                    @amount,
		                    @discount";
            using (DbConnection connection = Context.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                DbCommand command = connection.CreateCommand();
                command.CommandText = query;

                DbParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@customer_id";
                parameter.Value = addToCartDto.CustomerId;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@instrument_id";
                parameter.Value = addToCartDto.ItemId;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@amount";
                parameter.Value = addToCartDto.Amount;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@discount";
                parameter.Value = addToCartDto.Discount;
                command.Parameters.Add(parameter);

                count = await command.ExecuteNonQueryAsync();
            }
            return count > 0;
        }

        public async Task<IEnumerable<CartItemDto>> GetCartItems()
        {
            List<CartItemDto> items = new List<CartItemDto>();
            string query = "SELECT * FROM GetCartItems()";
            using (DbConnection connection = Context.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                DbCommand command = connection.CreateCommand();
                command.CommandText = query;

                using (DbDataReader reader = await command.ExecuteReaderAsync())
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

        public async Task<bool> FinishPurchase(int customerId)
        {
            int count = 0;
            string query = @$"EXEC  [dbo].[Sell]
                            @customer_id";
            using (DbConnection connection = Context.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                DbCommand command = connection.CreateCommand();
                command.CommandText = query;

                DbParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@customer_id";
                parameter.Value = customerId;
                command.Parameters.Add(parameter);

                count = await command.ExecuteNonQueryAsync();
            }
            return count > 0;
        }
    }
}
