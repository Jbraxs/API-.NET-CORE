using System;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProyectWeight.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CorpCustomersController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public CorpCustomersController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //Get api/customers
        [HttpGet]
        public IActionResult GetAllCorpCustomers()
        {
            try
            {
                var customer = _repository.CorpCustomers.GetAllCorpCustomers();

                _logger.LogInfo($"Returned all Corp Users from database.");

                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllCorpCustomers action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}", Name = "IdCustomers")]
        public IActionResult GetCustomerById(int id)
        {
            try
            {
                var customer = _repository.CorpCustomers.GetCustomerById(id);

                if (customer.FirstName == null)
                {
                    _logger.LogError($"Customer with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Customer with id: {id}");
                    return Ok(customer);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCustomerById action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}/weight")]
        public IActionResult GetCustomerWithDetails(int id)
        {
            try
            {
                var customer = _repository.CorpCustomers.GetCustomerWithDetails(id);

                if (customer.IdCustomers.Equals(null))
                {
                    _logger.LogError($"Customer with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Customer with details for id: {id}");
                    return Ok(customer);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCustomerWithDetails action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public IActionResult CreateCurstomer([FromBody]CorpCustomers customer)
        {
            try
            {
                if (customer == null)
                {
                    _logger.LogError("Customer object sent from client is null.");
                    return BadRequest("Customer object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Customer object sent from client.");
                    return BadRequest("Invalid model object");
                }
                _repository.CorpCustomers.CreateCustomer(customer);
                _repository.Save();

                _logger.LogInfo("Customer Created");
                return CreatedAtRoute("", new { Idcustomer = customer.IdCustomers }, customer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateCurstomer action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody]CorpCustomers customer)
        {
            try
            {
                if (customer == null)
                {
                    _logger.LogError("Customer object sent from client is null.");
                    return BadRequest("Customer object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Customer object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbCustomer = _repository.CorpCustomers.GetCustomerById(id);
                if (dbCustomer == null)
                {
                    _logger.LogError($"Customer with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.CorpCustomers.UpdateCustomer(dbCustomer, customer);
                _repository.Save();

                _logger.LogInfo($"Customer modified");
                return NoContent();
                //return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateCustomer action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id, int idw)
        {
            try
            {
                var weight = _repository.WeightControl.GetWeightControlById(idw);
                var customer = _repository.CorpCustomers.GetCustomerById(id);
                
                if (customer == null)
                {
                    _logger.LogError($"Customer with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.CorpCustomers.DeleteCustomer(customer);
                _repository.WeightControl.DeleteWeight(weight);
                _repository.Save();

                _logger.LogInfo($"Customer removed id: {id}, email: {customer.Email}");
                return NoContent();
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Something went wrong inside DeleteCustomer action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}