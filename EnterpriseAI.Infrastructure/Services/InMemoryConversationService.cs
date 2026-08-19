using EnterpriseAI.Application.Interfaces;
using OpenAI.Chat;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAI.Infrastructure.Services
{
    public class InMemoryConversationService : IConversationService
    {
        private readonly ConcurrentDictionary<Guid, List<ChatMessage>> _conversations = new();
        public void AddMessage(Guid conversationId, ChatMessage message)
        {
            if (!_conversations.TryGetValue(conversationId, out var messages)) 
            { 
                throw new KeyNotFoundException("Conversation not found.");
            }
            messages.Add(message);
        }

        public Guid CreateConversation()
        {
            var id = Guid.NewGuid();
            _conversations[id] = []; 
            return id;
        }

        public IReadOnlyList<ChatMessage> GetMessages(Guid conversationId)
        {
            if (!_conversations.TryGetValue(conversationId, out var messages)) 
            { 
                throw new KeyNotFoundException("Conversation not found."); 
            }
            return messages.AsReadOnly();
        }
    }
}
