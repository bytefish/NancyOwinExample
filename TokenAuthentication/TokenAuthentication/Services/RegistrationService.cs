// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using TokenAuthentication.Infrastructure.Database;
using TokenAuthentication.Infrastructure.Database.Entities;
using TokenAuthentication.Requests;

namespace TokenAuthentication.Services
{
    public class RegistrationService : BaseService, IRegistrationService
    {
        private readonly ICryptoService cryptoService;

        public RegistrationService(IDatabaseFactory databaseFactory, ICryptoService cryptoService)
            : base(databaseFactory)
        {
            this.cryptoService = cryptoService;
        }

        public void Register(RegisterUserRequest register)
        {
            using (var database = DatabaseFactory.GetDatabase())
            {
                // Let's do this in a transaction, so we cannot register two users
                // with the same name. Seems to be a useful requirement.
                using (var tran = database.GetTransaction())
                {
                    string hashBase64;
                    string saltBase64;

                    cryptoService.CreateHash(register.Password, out hashBase64, out saltBase64);

                    User user = new User()
                    {
                        Name = register.UserName,
                        PasswordHash = hashBase64,
                        PasswordSalt = saltBase64
                    };

                    database.Insert(user);

                    tran.Complete();
                }
            }
        }
    }
}