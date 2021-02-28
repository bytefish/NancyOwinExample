// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Owin.Hosting;
using System;

namespace TokenAuthentication
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string url = "http://localhost:8080";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
}