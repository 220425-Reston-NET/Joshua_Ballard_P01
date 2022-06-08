using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using CustomerBL;
using CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CustomerApi.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    { 
        //=================Dependency Injection=================//
        private ICustomerBL _customerBL;
        public CustomerController(ICustomerBL c_customerBL){
            _customerBL = c_customerBL;
        }

        //Data annotation to indicate what type of HTTP verb it is:
        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers(){
            try{
               List<Customer> listOfCurrentCustomers = await _customerBL.GetAllCustomersAsync();
            
               //Followed by "Ok()":
              return Ok(listOfCurrentCustomers);
            }
            catch(SqlException){
                return NotFound("No customer(s) exist.");
            }
        }

        [HttpPost("AddCustomers")]
        public IActionResult AddCustomer([FromBody] Customer c_customer){
            try{
                _customerBL.AddCustomer(c_customer);
                return Created("Customer was created!",c_customer);
            }
            catch(System.Exception){
                throw;
            }
            return Conflict();
        }

        [HttpGet("SearchCustomerByName")]
        public IActionResult SearchCustomer([FromQuery] string customerName){
            try{
                return Ok(_customerBL.SearchCustomerByName(customerName));
            }
            catch(SqlException){
                return Conflict();
            }
                
        }

        //[HttpPut("ReplenishInventory")]
        //public IActionResult ReplenishInventory(){
         //
         //   
         //   
        
    }
}