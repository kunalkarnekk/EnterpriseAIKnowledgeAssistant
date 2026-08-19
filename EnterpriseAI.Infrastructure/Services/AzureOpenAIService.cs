using EnterpriseAI.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAI.Infrastructure.Services
{
    public sealed class AzureOpenAIService : IAzureOpenAIService
    {
        private readonly ChatClient _chatClient;
        public AzureOpenAIService(
        AzureOpenAIOptions options)
        {
            var azureClient = new AzureOpenAIClient(
            new Uri(options.Endpoint),
            new AzureKeyCredential(options.ApiKey));
        }
        _chatClient = azureClient.GetChatClient(
        options.DeploymentName);
        public async Task<string> GetResponseAsync(
            string prompt,
            CancellationToken cancellationToken = default)
        {
            ChatCompletion completion =
            await _chatClient.CompleteChatAsync(
            11
            [
            new UserChatMessage(prompt)
            ],
            cancellationToken: cancellationToken);
            return completion.Content[0].Text;
        }
    }
}
