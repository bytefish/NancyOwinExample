// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NPoco;
using NPoco.FluentMappings;

namespace TokenAuthentication.Infrastructure.Database
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private NPoco.DatabaseFactory databaseFactory;

        public DatabaseFactory(IConnectionStringProvider connectionStringProvider, IMappingProvider mappingProvider)
        {   
            DatabaseFactoryConfigOptions options = new DatabaseFactoryConfigOptions();

            var connectionString = connectionStringProvider.GetConnectionString();
            var mappings = mappingProvider.GetMappings();

            options.Database = () => new LoggingDatabase(connectionString);
            options.PocoDataFactory = FluentMappingConfiguration.Configure(mappings);

            databaseFactory = new NPoco.DatabaseFactory(options);
        }
        
        public IDatabase GetDatabase()
        {
            return databaseFactory.GetDatabase();
        }
    }
}