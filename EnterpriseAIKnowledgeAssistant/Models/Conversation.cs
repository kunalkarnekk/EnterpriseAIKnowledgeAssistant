using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAI.Application.Models
{
    public sealed class Conversation
    {
        public Guid Id { get; init; }
        public List<ChatMessage> Messages { get; } = [];
    }
}
