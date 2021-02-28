// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace TokenAuthentication.Infrastructure.Database
{
    public class ConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }
    }
}