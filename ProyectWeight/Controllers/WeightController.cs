using System;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProyectWeight.Controllers
{
    [Route("api/weight")]
    [ApiController]
    public class WeightController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public WeightController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //Get api/weight
        [HttpGet]
        public IActionResult GetAllWeightControls()
        {
            try
            {
                var model = _repository.WeightControl.GetAllWeightControls();

                _logger.LogInfo($"Returned all WeightControl from database.");

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllWeightControls action: {ex}");
                return StatusCode(500, "Internal server error!!!!");
            }
        }
        [HttpGet("{id}", Name = "IdWeight")]
        public IActionResult GetWeightControlById(int id)
        {
            try 
            {
                var model = _repository.WeightControl.GetWeightControlById(id);

                if (model == null )
                {
                    _logger.LogError($"WeightControl with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else 
                {
                    _logger.LogInfo($"Returned Customer with id: {id}");
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetWeightControlById action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public IActionResult CreateWeight([FromBody] WeightControl weight)
        {
            try
            {
                if (weight == null)
                {
                    _logger.LogError("weight object sent from client is null.");
                    return BadRequest("weight object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid weight object sent from client.");
                    return BadRequest("Invalid model object");
                }
                _repository.WeightControl.CreateWeight(weight);
                _repository.Save();

                _logger.LogInfo("Customer Created");
                return CreatedAtRoute("", new { IdWeight = weight.IdWeight }, weight);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateWeigth action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateWeight(int id, [FromBody] WeightControl weight)
        {
            try
            {
                if (weight == null)
                {
                    _logger.LogError("UpdateWeigth object sent from client is null.");
                    return BadRequest("UpdateWeigth object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid UpdateWeigth object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbWeightControl = _repository.WeightControl.GetWeightControlById(id);
                if (dbWeightControl == null)
                {
                    _logger.LogError($"UpdateWeigth with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.WeightControl.UpdateWeight(dbWeightControl, weight);
                _repository.Save();

                _logger.LogInfo($"UpdateWeigth modified");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateWeigth action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWeight(int id)
        {
            try
            {
                var weight = _repository.WeightControl.GetWeightControlById(id);
                if (weight == null)
                {
                    _logger.LogError($"DeleteWeight with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.WeightControl.DeleteWeight(weight);
                _repository.Save();


                _logger.LogInfo($"DeleteWeight removed id: {id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteWeight action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}


