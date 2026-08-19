using EnterpriseAI.Application.Interfaces;
using EnterpriseAI.Application.Models;
using Microsoft.AspNetCore.Mvc;
using OpenAI.Chat;

namespace EnterpriseAI.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIController : Controller
    {
        private readonly IAzureOpenAIService _aiService;
        private readonly IConversationService _conversationService;
        public AIController(IAzureOpenAIService aiService , IConversationService conversationService) 
        { 
            _aiService = aiService;
            _conversationService = conversationService;
        }

        [HttpPost("chat")] 
        public async Task<IActionResult> Chat([FromBody] IReadOnlyList<ChatMessage> prompt, CancellationToken cancellationToken) 
        { 
            var response = await _aiService.GetResponseAsync(prompt, cancellationToken); 
            return Ok(new { response }); 
        }


        [HttpPost("conversation")] 
        public IActionResult CreateConversation() 
        { 
            var conversationId = _conversationService.CreateConversation(); 
            return Ok(new { conversationId });
        }

        [HttpPost("conversation/chat")] 
        public async Task<IActionResult> Chat(ChatRequest request, CancellationToken cancellationToken) 
        {
            var messages = _conversationService.GetMessages(request.ConversationId); 

            _conversationService.AddMessage(request.ConversationId, new UserChatMessage(request.Message)); 

            var updatedMessages = _conversationService.GetMessages(request.ConversationId); 

            var response = await _aiService.GetResponseAsync(updatedMessages, cancellationToken); 

            _conversationService.AddMessage(request.ConversationId, new AssistantChatMessage(response)); 

            return Ok(new { response }); 
        }

    }
}
