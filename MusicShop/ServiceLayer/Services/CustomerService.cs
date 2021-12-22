using MusicShop.DataLayer.Models;
using MusicShop.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.ServiceLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository { get; set; }
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<TopCustomer>> GetTopCustomers()
        {
            return await _customerRepository.GetTopCustomers();
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customerRepository.GetAll();
        }
    }
}
