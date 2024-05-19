using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Test_ST.Models;
using Test_ST.Services;
using Test_ST.ViewModels;

namespace Test_ST.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForms()
        {
            var forms = await _formService.GetAllFormsAsync();
            return Ok(forms);
        }

        [HttpGet]
        public async Task<IActionResult> GetFormById(int id)
        {
            if (id == 0 || id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var form = await _formService.GetFormByIdAsync(id);
            if (form == null)
            {
                return NotFound();
            }
            return Ok(form);
        }

        [HttpPost]
        public async Task<IActionResult> CreateForm(FormRequest form)
        {
            if (!ModelState.IsValid || form == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var createdForm = await _formService.CreateFormAsync(form);
            return Ok(createdForm);
        }
    }
}
