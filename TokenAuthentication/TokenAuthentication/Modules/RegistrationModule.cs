
// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using TokenAuthentication.Requests;
using TokenAuthentication.Services;
using Nancy;
using Nancy.ModelBinding;

namespace TokenAuthentication.Modules
{
    public class RegistrationModule : NancyModule
    {
        public RegistrationModule(IRegistrationService registrationService)
        {
            Post["/register"] = x =>
            {
                var request = this.Bind<RegisterUserRequest>();

                registrationService.Register(request);

                return Negotiate.WithStatusCode(HttpStatusCode.OK);
            };
        }
    }
}