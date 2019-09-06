using CustomerAccountServer.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace CustomerAccountServer.Controllers
{
    //Routing directs any Incoming HttpRequests to a particular action method inside the Web API Controller.
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public CustomerController(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }


        //if there's no route attribute on this action
        // the api endpoint for this action will default to api/customer
        //[Route("getallcustomers")]
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _repositoryUnitOfWork.Customer.GetAllCustomers();
                Log.Information("Returned all customers from database.");
                //for status code 200 = OK
                return Ok(customers);
            }
            catch (Exception exception)
            {
                Log.Error($"Something went wrong inside GetAllCustomers action: {exception.Message}");
                //for internal server error = 500
                return StatusCode(500, "Internal server error");
            }
        }

        //[Route("getcustomerbyid/{customerId}")]
        [HttpGet("{customerId}")]
        public IActionResult GetCustomerById(int customerId)
        {
            try
            {
                var customer = _repositoryUnitOfWork.Customer.GetCustomerById(customerId);

                if (customer.Id.Equals(default))
                {
                    Log.Error($"Customer with id: {customerId}, has not been found in db.");
                    return NotFound();
                }

                else
                {
                    Log.Information($"Returned customer with id: {customerId}");
                    return Ok(customer);
                }
            }
            catch (Exception exception)
            {
                Log.Error($"Something went wrong inside GetCustomerById action: {exception.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{customerId}/account")]
        public IActionResult GetCustomerWithDetails(int customerId)
        {
            try
            {
                var customer = _repositoryUnitOfWork.Customer.GetCustomerWithDetails(customerId);

                if (customer.Id.Equals(default))
                {
                    Log.Error($"Customer with id: {customerId}, has not been found in database.");
                    return NotFound();
                }

                else
                {
                    Log.Information($"Returned customer with details for id: {customerId}");
                    return Ok(customer);
                }
            }
            catch (Exception exception)
            {
                Log.Error($"Something went wrong inside GetCustomerWithDetails action: {exception.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}



//Notes on Routing in .NetCore Web APIs:
//Web API routing routes the incoming HTTP requests to the particular action method inside Web API controller.
//There are two types of routings:

//- Convention based routing and
//- Attribute routing

//1. Convention based routing is called that way because it establishes a convention for the URL paths. 

// The first part makes the mapping for the controller name, the second part makes the mapping for the action method and the third part is used for the optional parameter. 
// You can configure this type of routing in the Startup class in the Configure method: 

//    Example: in the startup.cs we could do:

//    app.UseMvc(routes => 
//    {
//    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
//    });

//2. Attribute routing uses the attributes to map the routes directly to the action methods inside the controller.Usually, 
//   we place the base rout above the controller class, as you can notice in our Web API controller class. 
//   Similarly, for the specific action methods, we create their routes right above them.