using Microsoft.Owin;
using Owin;
using Reminder.Models;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(Reminder.Startup))]
namespace Reminder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        //private void ConfigureControllerFactory()
        //{
        //    IControllerFactory factory = new CustomControllerFactory();
        //    ControllerBuilder.Current.SetControllerFactory(factory);
        //}
    }
}
