﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DockerWebAPI2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:5100")
                .Build();
    }
}
