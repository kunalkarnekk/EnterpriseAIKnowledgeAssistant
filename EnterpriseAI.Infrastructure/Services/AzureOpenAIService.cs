using Azure;
using Azure.AI.OpenAI;
using EnterpriseAI.Application.Interfaces;
using EnterpriseAI.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAI.Infrastructure.Services
{
    public sealed class AzureOpenAIService : IAzureOpenAIService
    {
        private readonly ChatClient _chatClient;
        public AzureOpenAIService(AzureOpenAIOptions options)
        {
            var azureClient = new AzureOpenAIClient(new Uri(options.Endpoint),new AzureKeyCredential(options.ApiKey));
            _chatClient = azureClient.GetChatClient(options.DeploymentName);
        }


        public async Task<string> GetResponseAsync(
            IReadOnlyList<ChatMessage> messages,
            CancellationToken cancellationToken = default)
        {
            ChatCompletion completion = 
                await _chatClient.CompleteChatAsync(messages, cancellationToken: cancellationToken);
            return completion.Content[0].Text;
        }
    }
}
