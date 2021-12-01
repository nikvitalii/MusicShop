using Microsoft.AspNetCore.Mvc;
using MusicShop.DataLayer.Models;
using MusicShop.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService { get; set; }

        public CustomerController(ICustomerService customerService) 
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] object user)
        {
            var res = true;
            return Ok(res);
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customerService.GetCustomers();
        }

        [HttpGet]
        [Route("TopCustomers")]
        public async Task<IEnumerable<TopCustomer>> GetTopCustomers()
        {
            return await _customerService.GetTopCustomers();
        }

    }
}
