// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;

namespace TokenAuthentication.Model
{
    /// <summary>
    /// Represents a UserIdentity with a Users Name and Claims.
    /// </summary>
    public class UserIdentity
    {
        public int Id {get; set; }

        public string Name { get; set; }

        public IList<ClaimIdentity> Claims { get; set; }
    }
}
