using System;
using System.Collections.Generic;
using lego.Models;
using lego.Services;
using Microsoft.AspNetCore.Mvc;

namespace lego.Controllers
{
    public class KitsController : ControllerBase
    {
        private readonly KitsService _service;

        public KitsController(KitsService service)
        {
            _service = service;
        }

        [HttpGet]  // GETALL
        public ActionResult<IEnumerable<Kit>> GetAll()
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
        public ActionResult<Kit> GetById(int id)
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
        public ActionResult<Kit> Create([FromBody] Kit newKit)
        {
            try
            {
                return Ok(_service.Create(newKit));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")] // PUT
        public ActionResult<Kit> Edit([FromBody] Kit editKit, int id)
        {
            try
            {
                editKit.Id = id;
                return Ok(_service.Edit(editKit));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")] // DELETE
        public ActionResult<Kit> Delete(int id)
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