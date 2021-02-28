// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NPoco.FluentMappings;
using TokenAuthentication.Infrastructure.Database.Entities;

namespace TokenAuthentication.Infrastructure.Database.Mapping
{
    public class UserClaimsMapping : Map<UserClaims>
    {
        public UserClaimsMapping()
        {
            PrimaryKey(p => p.Id, autoIncrement: true)
                .TableName("auth.user_claim")
                .Columns(x =>
                {
                    x.Column(p => p.Id).WithName("user_claim_id");
                    x.Column(p => p.UserId).WithName("user_id");
                    x.Column(p => p.ClaimId).WithName("claim_id");
                });
        }
    }
}