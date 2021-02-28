// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Nancy.TinyIoc;
using Owin;
using System;
using TokenAuthentication.Infrastructure.Authentication;
using TokenAuthentication.Infrastructure.Database;
using TokenAuthentication.Services;

namespace TokenAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            TinyIoCContainer container = new TinyIoCContainer();

            // Register Dependencies:
            RegisterDependencies(container);

            // Initialize Authentication:
            SetupAuth(app, container);

            // Initialize Nancy:
            SetupNancy(app, container);

        }

        private void RegisterDependencies(TinyIoCContainer container)
        {
            // Make some Registrations:
            container.Register<IMappingProvider, MappingProvider>();
            container.Register<IConnectionStringProvider, ConnectionStringProvider>();
            container.Register<IDatabaseFactory, DatabaseFactory>().AsSingleton();
            container.Register<IApplicationSettings, ApplicationSettings>();
            container.Register<ICryptoService, CryptoService>();
            container.Register<IRegistrationService, RegistrationService>();
            container.Register<IHashProvider, HashProvider>();
            container.Register<IAuthenticationService, AuthenticationService>();
        }

        private void SetupAuth(IAppBuilder app, TinyIoCContainer container)
        {
            var settings = container.Resolve<IApplicationSettings>();

            // Use default options:
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()
            {
                Provider = new OAuthTokenProvider(
                    req => req.Query.Get("bearer_token"),
                    req => req.Query.Get("access_token"),
                    req => req.Query.Get("token"),
                    req => req.Headers.Get("X-Token"))
            });

            // Register a Token-based Authentication for the App:            
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true, // you should use this for debugging only
                TokenEndpointPath = new PathString(settings.TokenEndpointBasePath),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(8),
                Provider = new SimpleAuthorizationServerProvider(container.Resolve<IAuthenticationService>()),
            });
        }

        private void SetupNancy(IAppBuilder app, TinyIoCContainer container)
        {
            var settings = container.Resolve<IApplicationSettings>();

            app.Map(settings.NancyBasePath, siteBuilder => siteBuilder.UseNancy());
        }
    }
}