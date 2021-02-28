// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Configuration;

namespace TokenAuthentication.Infrastructure.Database
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public ConnectionStringSettings GetConnectionString()
        {
            if (ConfigurationManager.ConnectionStrings["ApplicationConnectionString"] != null)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["ApplicationConnectionString"];

                return new ConnectionStringSettings
                {
                    ConnectionString = connectionString.ConnectionString,
                    ProviderName = connectionString.ProviderName
                };
            }

            throw new InvalidOperationException("ConnectionString with Name ApplicationConnectionString was not found");
        }
    }
}