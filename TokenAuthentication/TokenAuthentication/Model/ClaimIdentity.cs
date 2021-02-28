// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace TokenAuthentication.Model
{
    /// <summary>
    /// Represents a Claim with a Type and a Value.
    /// </summary>
    public class ClaimIdentity
    {
        public int Id { get; set; }

        public string Type { get; set; }
        
        public string Value { get; set; }
    }
}
