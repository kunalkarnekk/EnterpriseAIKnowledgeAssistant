using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAI.Application.Interfaces
{
    public interface IConversationService
    {
        Guid CreateConversation();
        IReadOnlyList<ChatMessage> GetMessages(Guid conversationId);
        void AddMessage(Guid conversationId, ChatMessage message);
    }
}
