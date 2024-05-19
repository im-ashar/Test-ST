using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_ST.Services;
using Test_ST.ViewModels;

namespace Test_ST.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(List<QuestionRequest> question)
        {
            if (!ModelState.IsValid || question == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var createdQuestion = await _questionService.CreateQuestionAsync(question);
            return Ok(createdQuestion);
        }
    }
}
