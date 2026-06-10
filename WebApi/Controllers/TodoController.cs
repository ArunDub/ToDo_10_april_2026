using Application.Dtos;
using Application.Helpers;
using Application.Helpers.Extensions;
using Application.Intrerfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IDataService _service;
        public TodoController(IDataService service)
        {
            _service = service;
        }
        // GET: api/TodoLists/Get
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var modelvms = await _service.TodoService.Get();
            if (modelvms == null || modelvms.Count <= 0)
                return NotFound(ApiResponseBuilder.GenerateNotfound("Get Failed", "Record notfound"));
            return Ok(ApiResponseBuilder.GenerateOK(modelvms,200, "Ok", $"{modelvms.Count}record (s) Fetched"));
        }

        // GET api/TodoLists/Get/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Get Failed", "Invalid input"));
            
            var modelDto = await _service.TodoService.Get(id);
            if (modelDto == null)
            
                return NotFound(ApiResponseBuilder.GenerateNotfound("Get Failed", $"Record with {id} Not Found"));
            
            return Ok(ApiResponseBuilder.GenerateOK(modelDto, 200, "Ok", $"Record with{id} fetched"));
        }

        // POST api/TodoLists/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoDto modelDto) 
        {
            if (modelDto == null)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Create Failed", "Input not valid or null"));
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetModelStateErrors();
                if (errors != null && errors.Count > 0)
                {
                    var msgBuilder = new StringBuilder();
                    foreach (var error in errors)
                    {
                        msgBuilder.AppendLine(error.ToString());
                    }
                    return BadRequest(ApiResponseBuilder.GenerateBadRequest("Create Failed", msgBuilder.ToString()));
                }
            }

            var createdDto = await _service.TodoService.Create(modelDto);
            if (createdDto == null)
            return BadRequest(ApiResponseBuilder.GenerateBadRequest("Create failed", "Some Errro occured"));
           return Ok(ApiResponseBuilder.GenerateOK(createdDto,200, "Created Successfully", $"Record created at api/TodoList/Get/{createdDto.Id}"));
        }

        // PUT api/TodoLists/Update/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TodoDto modelDto)
        {
            if (id <= 0 || modelDto == null || modelDto.Id != id)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Update Failed", "Invalid input"));
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetModelStateErrors();
                if (errors != null && errors.Count > 0)
                {
                    var msgBuilder = new StringBuilder();
                    foreach (var error in errors)
                    {
                        msgBuilder.AppendLine(error.ToString());
                    }
                    return BadRequest(ApiResponseBuilder.GenerateBadRequest("Update failed", msgBuilder.ToString()));
                }
            }
            var updatedDto = await _service.TodoService.Update(modelDto);
            if (updatedDto == null)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Update failed", "some error occurd"));
            }
            return Ok(ApiResponseBuilder.GenerateOK(updatedDto, 200, "OK", "Record updated successfully"));
        }

        // DELETE api/TodoLists/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task <IActionResult>Delete(int id)
        {
            if(id<=0)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Delete failed", "Invalid input"));
            }
            var rowsAffected = await _service.TodoService.Delete(id);
            if(rowsAffected<=0)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Delete Failed", "There might be active child record(s)"));
            }
            return Ok(ApiResponseBuilder.GenerateOK(rowsAffected, 200, "Ok", $"Record with id {id} Deleted"));
        }
        //POST TodoLists/CreateRange
        [HttpPost("CreateRange")]
        public async Task<IActionResult> CreatRange([FromBody] List<TodoDto> modelDto)
        {
            if (modelDto == null)
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk create failed", "Input is null"));
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetModelStateErrors();
                if (errors != null && errors.Count > 0)
                {
                    var msgBuilder = new StringBuilder();
                    foreach (var error in errors)
                    {
                        msgBuilder.AppendLine(error.ToString());
                    }
                    return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Create Failed", msgBuilder.ToString()));
                }
            }
            var createdDtos = await _service.TodoService.CreateRange(modelDto);
            if (createdDtos == null || createdDtos.Count <= 0)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Create Failed", "Some errors occured"));
            }
            else
            {
                return Ok(ApiResponseBuilder.GenerateOK(createdDtos, 200, "OK", "Bulk Create Success"));
            }
        }
        //POST TodoLists/UpdateRange
        [HttpPost("UpdateRange")]
        public async Task<IActionResult> UpdateRange([FromBody] List<TodoDto> modelDtos)
        {
            if (modelDtos == null || modelDtos.Count <= 0)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Update Failed", "input is null"));
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetModelStateErrors();
                if (errors != null)
                {
                    var msgBulder = new StringBuilder();

                    foreach (var eror in errors)
                    {
                        msgBulder.AppendLine(eror.ToString());
                    }
                    return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Update Failed", msgBulder.ToString()));
                }
            }
            var updatedDto = await _service.TodoService.UpdateRange(modelDtos);
            if (updatedDto == null || updatedDto.Count <= 0)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Update Failed", "some error occured"));
            }
            else
            {
                return Ok(ApiResponseBuilder.GenerateOK(updatedDto, 200, "Ok", "Bulk Update Success"));
            }
        }
        //POST TodoLists/DeleteRange
        [HttpPost("DeleteRange")]
        public async Task<IActionResult> DeleteRange([FromBody] List<TodoDto> modelDtos)
        {
            if (modelDtos == null || modelDtos.Count <= 0)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Delete Failed", "Input is null"));
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetModelStateErrors();
                if (errors != null)
                {
                    var msgBuiler = new StringBuilder();
                    foreach (var error in errors)
                    {
                        msgBuiler.AppendLine(error.ToString());
                    }
                    return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Delete Failed", msgBuiler.ToString()));
                }
            }
            var rowsAffected = await _service.TodoService.DeleteRange(modelDtos);
            if (rowsAffected <= 0)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Update Failed", "There might be some active child record"));
            }
            else
            {
                return Ok(ApiResponseBuilder.GenerateOK(rowsAffected, 200, "OK", "Bulk delete success"));
            }
        }
    }
}
