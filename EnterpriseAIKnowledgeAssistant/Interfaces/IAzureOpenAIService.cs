using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAI.Application.Interfaces
{
    public interface IAzureOpenAIService
    {
        Task<string> GetResponseAsync(string prompt, CancellationToken cancellationToken = default);
    }
}
