using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using test_app1.Models;
namespace test_app1.Controllers
{
    public class NinjectController:DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectController()
        {
            ninjectKernel = new StandardKernel();
            AddBind();
        }
        void AddBind()
        {
            ninjectKernel.Bind<IStudentBL>().To<StudentBLSQLServer>();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
    }
}