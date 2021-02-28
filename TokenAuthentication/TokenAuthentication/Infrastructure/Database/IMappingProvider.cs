// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NPoco.FluentMappings;

namespace TokenAuthentication.Infrastructure.Database
{
    public interface IMappingProvider
    {
        IMap[] GetMappings();
    }
}