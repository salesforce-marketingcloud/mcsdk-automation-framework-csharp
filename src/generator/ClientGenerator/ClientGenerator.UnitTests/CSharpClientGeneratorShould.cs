using System;
using System.Collections.Generic;
using ClientGenerator.Core;
using NUnit.Framework;

namespace ClientGenerator.UnitTests
{
    public class CSharpClientGeneratorShould
    {
        [TestCase("FooApi", @"        private FooApi fooApi;
        public FooApi FooApi
        {
            get => this.fooApi ?? (this.fooApi = new FooApi(this.authBaseUrl, this.clientId, this.clientSecret, this.accountId, this.scope));
            internal set => this.fooApi = value;
        }
")]
        [TestCase("BarApi", @"        private BarApi barApi;
        public BarApi BarApi
        {
            get => this.barApi ?? (this.barApi = new BarApi(this.authBaseUrl, this.clientId, this.clientSecret, this.accountId, this.scope));
            internal set => this.barApi = value;
        }
")]
        public void GenerateClientClassPropertyFromApiClassName(string apiClassName, string expected)
        {
            var generatedProperty = CSharpClientGenerator.GenerateProperty(apiClassName);

            Assert.That(generatedProperty, Is.EqualTo(expected));
        }

        [TestCase(new[] { "FooApi", "BarApi" }, @"using Salesforce.MarketingCloud.Infrastructure;

namespace Salesforce.MarketingCloud.Api
{
    public class Client
    {
        private readonly string authBaseUrl;
        private readonly string clientId;
        private readonly string clientSecret;
        private readonly string accountId;
        private readonly string scope;

        /// <summary>
        /// Initializes a new instance of the <see cref=""Client""/> class.
        /// <para>  In order for this an instance to be successfully created, the following env variables must be set:</para>
        /// <para>  SFMC_AUTH_BASE_URL - Your tenant-specific Authentication Base URI.</para>
        /// <para>  SFMC_CLIENT_ID - Client ID issued when you create the API integration in Installed Packages.</para>
        /// <para>  SFMC_CLIENT_SECRET - Client secret issued when you create the API integration in Installed Packages.</para>
        /// <para>  SFMC_ACCOUNT_ID - Account identifier, or MID, of the target business unit. Use to switch between business units.</para>
        /// <para>  Optional - SFMC_SCOPE - Space-separated list of data-access permissions for your application.</para>
        /// </summary>
        public Client()
        {
            EnvironmentConfigProvider configProvider = new EnvironmentConfigProvider();
            this.authBaseUrl = configProvider.Get(EnvVariableName.AUTH_BASE_URL);
            this.clientId = configProvider.Get(EnvVariableName.CLIENT_ID);
            this.clientSecret = configProvider.Get(EnvVariableName.CLIENT_SECRET);
            this.accountId = configProvider.Get(EnvVariableName.ACCOUNT_ID);
            this.scope = configProvider.Get(EnvVariableName.SCOPE, false);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref=""Client""/> class.
        /// </summary>
        /// <param name=""authBaseUrl"">Your tenant-specific Authentication Base URI.</param>
        /// <param name=""clientId"">Client ID issued when you create the API integration in Installed Packages.</param>
        /// <param name=""clientSecret"">Client secret issued when you create the API integration in Installed Packages.</param>
        /// <param name=""accountId"">Account identifier, or MID, of the target business unit. Use to switch between business units.</param>
        /// <param name=""scope"">Space-separated list of data-access permissions for your application.</param>
        public Client(string authBaseUrl, string clientId, string clientSecret, string accountId, string scope = null)
        {
            this.authBaseUrl = authBaseUrl;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.accountId = accountId;
            this.scope = scope;
        }

        private FooApi fooApi;
        public FooApi FooApi
        {
            get => this.fooApi ?? (this.fooApi = new FooApi(this.authBaseUrl, this.clientId, this.clientSecret, this.accountId, this.scope));
            internal set => this.fooApi = value;
        }
        private BarApi barApi;
        public BarApi BarApi
        {
            get => this.barApi ?? (this.barApi = new BarApi(this.authBaseUrl, this.clientId, this.clientSecret, this.accountId, this.scope));
            internal set => this.barApi = value;
        }
    }
}")]
        public void GenerateClientClass(IEnumerable<string> apiClassNames, string expected)
        {
            var generatedClientClass = CSharpClientGenerator.GenerateClientClass(apiClassNames);
            Console.WriteLine(generatedClientClass);

            Assert.That(generatedClientClass, Is.EqualTo(expected));
        }
    }
}