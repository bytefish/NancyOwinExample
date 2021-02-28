// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NPoco.FluentMappings;
using TokenAuthentication.Infrastructure.Database.Entities;

namespace TokenAuthentication.Infrastructure.Database.Mapping
{
    public class UserMapping : Map<User>
    {
        public UserMapping()
        {
            PrimaryKey(p => p.Id, autoIncrement: true)
                .TableName("auth.user")
                .Columns(x =>
                {
                    x.Column(p => p.Id).WithName("user_id");
                    x.Column(p => p.Name).WithName("name");
                    x.Column(p => p.PasswordHash).WithName("password_hash");
                    x.Column(p => p.PasswordSalt).WithName("password_salt");
                });
        }
    }
}