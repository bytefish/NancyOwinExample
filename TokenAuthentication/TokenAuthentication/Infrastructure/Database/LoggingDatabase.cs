// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using log4net;
using System.Data;
using System.Reflection;

namespace TokenAuthentication.Infrastructure.Database
{
    public class LoggingDatabase : NPoco.Database
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public LoggingDatabase(ConnectionStringSettings connectionString) 
            : base(connectionString.ConnectionString, connectionString.ProviderName) { }

        protected override void OnExecutingCommand(IDbCommand cmd)
        {
            if (log.IsDebugEnabled)
            {
                log.Debug(FormatCommand(cmd));
            }
        }

        protected override void OnException(System.Exception exception)
        {
            base.OnException(exception);

            if (log.IsErrorEnabled)
            {
                log.Error(exception);
            }
        }
    }
}