using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAI.Application.Models
{
    public sealed class ChatRequest
    {
        public Guid ConversationId { get; init; }
        public string Message { get; init; } = string.Empty;
    }
}
