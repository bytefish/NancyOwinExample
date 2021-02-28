// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace TokenAuthentication.Infrastructure.Database.Entities
{
    public class Claim : Entity
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return string.Format("Claim ({0}, Type: {1}, Value: {2}", base.ToString(), Type, Value);
        }
    }
}