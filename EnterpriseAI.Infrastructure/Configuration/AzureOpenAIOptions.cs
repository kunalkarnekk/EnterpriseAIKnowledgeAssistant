using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAI.Infrastructure.Configuration
{
    public sealed class AzureOpenAIOptions
    {
        public string Endpoint { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty; 
        public string DeploymentName { get; set; } = string.Empty;
    }
}
