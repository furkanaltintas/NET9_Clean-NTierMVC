using Business.Abstract.Base;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Base
{
    public class ControllerManager : Controller
    {
        protected readonly IServiceManager _manager;

        public ControllerManager(IServiceManager manager) { _manager = manager; }
    }
}