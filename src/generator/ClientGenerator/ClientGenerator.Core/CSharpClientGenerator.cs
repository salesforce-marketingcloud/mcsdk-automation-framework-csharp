using System.Collections.Generic;
using System.Text;

namespace ClientGenerator.Core
{
    public static class CSharpClientGenerator
    {
        public static string GenerateProperty(string apiClassName)
        {
            var apiClassVariableName = apiClassName.Substring(0,1).ToLower() + apiClassName.Substring(1);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"        private {apiClassName} {apiClassVariableName};");
            sb.AppendLine($"        public {apiClassName} {apiClassName}");
            sb.AppendLine("        {");
            sb.AppendLine($"            get => this.{apiClassVariableName} ?? (this.{apiClassVariableName} = new {apiClassName}(this.authBaseUrl, this.clientId, this.clientSecret, this.accountId, this.scope));");
            sb.AppendLine($"            internal set => this.{apiClassVariableName} = value;");
            sb.AppendLine("        }");

            return sb.ToString();
        }

        public static string GenerateClientClass(IEnumerable<string> apiClassNames)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using Salesforce.MarketingCloud.Infrastructure;");
            sb.AppendLine();
            sb.AppendLine("namespace Salesforce.MarketingCloud.Api");
            sb.AppendLine("{");
            sb.AppendLine("    public class Client");
            sb.AppendLine("    {");
            sb.AppendLine("        private readonly string authBaseUrl;");
            sb.AppendLine("        private readonly string clientId;");
            sb.AppendLine("        private readonly string clientSecret;");
            sb.AppendLine("        private readonly string accountId;");
            sb.AppendLine("        private readonly string scope;");
            sb.AppendLine();
            sb.AppendLine(@"        /// <summary>");
            sb.AppendLine(@"        /// Initializes a new instance of the <see cref=""Client""/> class.");
            sb.AppendLine(@"        /// <para>  In order for this an instance to be successfully created, the following env variables must be set:</para>");
            sb.AppendLine(@"        /// <para>  SFMC_AUTH_BASE_URL - Your tenant-specific Authentication Base URI.</para>");
            sb.AppendLine(@"        /// <para>  SFMC_CLIENT_ID - Client ID issued when you create the API integration in Installed Packages.</para>");
            sb.AppendLine(@"        /// <para>  SFMC_CLIENT_SECRET - Client secret issued when you create the API integration in Installed Packages.</para>");
            sb.AppendLine(@"        /// <para>  SFMC_ACCOUNT_ID - Account identifier, or MID, of the target business unit. Use to switch between business units.</para>");
            sb.AppendLine(@"        /// <para>  Optional - SFMC_SCOPE - Space-separated list of data-access permissions for your application.</para>");
            sb.AppendLine(@"        /// </summary>");
            sb.AppendLine("        public Client()");
            sb.AppendLine("        {");
            sb.AppendLine("            EnvironmentConfigProvider configProvider = new EnvironmentConfigProvider();");
            sb.AppendLine("            this.authBaseUrl = configProvider.Get(EnvVariableName.AUTH_BASE_URL);");
            sb.AppendLine("            this.clientId = configProvider.Get(EnvVariableName.CLIENT_ID);");
            sb.AppendLine("            this.clientSecret = configProvider.Get(EnvVariableName.CLIENT_SECRET);");
            sb.AppendLine("            this.accountId = configProvider.Get(EnvVariableName.ACCOUNT_ID);");
            sb.AppendLine("            this.scope = configProvider.Get(EnvVariableName.SCOPE, false);");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine(@"        /// <summary>");
            sb.AppendLine(@"        /// Initializes a new instance of the <see cref=""Client""/> class.");
            sb.AppendLine(@"        /// </summary>");
            sb.AppendLine(@"        /// <param name=""authBaseUrl"">Your tenant-specific Authentication Base URI.</param>");
            sb.AppendLine(@"        /// <param name=""clientId"">Client ID issued when you create the API integration in Installed Packages.</param>");
            sb.AppendLine(@"        /// <param name=""clientSecret"">Client secret issued when you create the API integration in Installed Packages.</param>");
            sb.AppendLine(@"        /// <param name=""accountId"">Account identifier, or MID, of the target business unit. Use to switch between business units.</param>");
            sb.AppendLine(@"        /// <param name=""scope"">Space-separated list of data-access permissions for your application.</param>");
            sb.AppendLine("        public Client(string authBaseUrl, string clientId, string clientSecret, string accountId, string scope = null)");
            sb.AppendLine("        {");
            sb.AppendLine("            this.authBaseUrl = authBaseUrl;");
            sb.AppendLine("            this.clientId = clientId;");
            sb.AppendLine("            this.clientSecret = clientSecret;");
            sb.AppendLine("            this.accountId = accountId;");
            sb.AppendLine("            this.scope = scope;");
            sb.AppendLine("        }");
            sb.AppendLine();
            foreach (var apiClassName in apiClassNames)
            {
                sb.Append(GenerateProperty(apiClassName));
            }
            sb.AppendLine("    }");
            sb.Append("}");
            return sb.ToString();
        }
    }
}