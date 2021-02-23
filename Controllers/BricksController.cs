using System;
using System.Collections.Generic;
using lego.Models;
using lego.Services;
using Microsoft.AspNetCore.Mvc;

namespace lego.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BricksController : ControllerBase
    {
        private readonly BricksService _service;

        public BricksController(BricksService service)
        {
            _service = service;
        }

        [HttpGet]  // GETALL
        public ActionResult<IEnumerable<Brick>> GetAll()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("{id}")] // GETBYID
        public ActionResult<Brick> GetById(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost] // POST
        public ActionResult<Brick> Create([FromBody] Brick newBrick)
        {
            try
            {
                return Ok(_service.Create(newBrick));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")] // PUT
        public ActionResult<Brick> Edit([FromBody] Brick editBrick, int id)
        {
            try
            {
                editBrick.Id = id;
                return Ok(_service.Edit(editBrick));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")] // DELETE
        public ActionResult<Brick> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}