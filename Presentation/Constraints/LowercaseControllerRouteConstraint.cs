using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Presentation.Constraints
{
    public class LowercaseControllerRouteConstraint : IControllerModelConvention
    {
        public void Apply(ControllerModel controller) =>
            controller.ControllerName = controller.ControllerName.ToLower();
    }
}