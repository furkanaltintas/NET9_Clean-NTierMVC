﻿using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

public class ResumeController : ControllerManager
{
    [Route("resume")]
    public IActionResult Index() => View();
}