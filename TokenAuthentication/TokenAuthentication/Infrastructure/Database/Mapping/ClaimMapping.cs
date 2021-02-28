// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NPoco.FluentMappings;
using TokenAuthentication.Infrastructure.Database.Entities;

namespace TokenAuthentication.Infrastructure.Database.Mapping
{
    public class ClaimMapping : Map<Claim>
    {
        public ClaimMapping()
        {
            PrimaryKey(p => p.Id, autoIncrement: true)
                .TableName("auth.claim")
                .Columns(x =>
                {
                    x.Column(p => p.Id).WithName("claim_id");
                    x.Column(p => p.Type).WithName("type");
                    x.Column(p => p.Value).WithName("value");
                });
        }
    }
}