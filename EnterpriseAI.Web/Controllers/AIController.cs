using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAI.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIController : Controller
    {
        private readonly IAzureOpenAIService _aiService;

        public AIController(IAzureOpenAIService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost("chat")]
        public async Task<IActionResult> Chat(
            [FromBody] string prompt,
            CancellationToken cancellationToken)
        {
            var response =
            await _aiService.GetResponseAsync(
            prompt,
            cancellationToken);
            return Ok(new
            {
                response
            });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
