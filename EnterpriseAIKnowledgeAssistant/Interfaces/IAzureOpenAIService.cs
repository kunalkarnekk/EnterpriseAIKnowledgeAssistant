using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAI.Application.Interfaces
{
    public interface IAzureOpenAIService
    {
        Task<string> GetResponseAsync(IReadOnlyList<ChatMessage> Messages, CancellationToken cancellationToken = default);
    }
}
