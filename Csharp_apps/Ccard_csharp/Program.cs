﻿using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Ccard_csharp

{
    public class Program
    {
        public static void Main(string[] args)
        {
            //This is a method generated by the dotnet new web command
            //It is in place to build a Kestrel webserver and attach your startup.cs file to it.
            //Kestrel is the default webserver ASP.NET Core runs on.
            //We will not need to alter this code in any way!
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}