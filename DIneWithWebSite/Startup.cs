﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DIneWithWebSite.Startup))]
namespace DIneWithWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}