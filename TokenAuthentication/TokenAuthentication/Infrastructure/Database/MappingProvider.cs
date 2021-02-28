// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NPoco.FluentMappings;
using TokenAuthentication.Infrastructure.Database.Mapping;

namespace TokenAuthentication.Infrastructure.Database
{
    public class MappingProvider : IMappingProvider
    {
        public IMap[] GetMappings()
        {
            return new IMap[] { new UserMapping(), new ClaimMapping(), new UserClaimsMapping() };
        }
    }
}