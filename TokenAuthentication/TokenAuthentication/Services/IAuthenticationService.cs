// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using TokenAuthentication.Infrastructure.Authentication;
using TokenAuthentication.Model;

namespace TokenAuthentication.Services
{
    /// <summary>
    /// An Authentication Service to authenticate incoming requests.
    /// </summary>
    public interface IAuthenticationService
    {
        bool TryAuthentifcate(Credentials request, out UserIdentity identity);
    }
}