using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reminder.Controllers;
using Reminder.Models.DataModels;
using Reminder.Models.Interfaces;

namespace Reminder.Models
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            IReminderRepository repository = new ReminderRepository(new ReminderDbContext());
            IController controller = Activator.CreateInstance(controllerType, new[] {repository}) as Controller;

            return controller;
        }
    }
}