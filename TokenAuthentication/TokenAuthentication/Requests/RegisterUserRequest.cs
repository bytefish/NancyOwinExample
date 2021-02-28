// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace TokenAuthentication.Requests
{
    public class RegisterUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
