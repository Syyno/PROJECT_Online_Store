using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Linq;

namespace MyProjectOnlineShop.Services
{
    public class AdminAuthorization : IControllerModelConvention
    {
        private readonly string _area;
        private readonly string _policy;

        public AdminAuthorization(string area, string policy)
        {
            _area = area;
            _policy = policy;
        }

        public void Apply(ControllerModel controller)
        {
            if (controller.Attributes.Any(x =>
                   x is AreaAttribute 
                   && (x as AreaAttribute).RouteValue.Equals(_area, StringComparison.OrdinalIgnoreCase)) 
                || 
                controller.RouteValues.Any(y =>
                    y.Key.Equals("area", StringComparison.OrdinalIgnoreCase) 
                    && y.Value.Equals(_area, StringComparison.OrdinalIgnoreCase)))
            {
                controller.Filters.Add(new AuthorizeFilter(_policy));
            }
        }
    }
}
