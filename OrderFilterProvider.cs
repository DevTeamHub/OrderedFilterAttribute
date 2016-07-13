using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DevTeam.OrderedFilterAttribute
{
    public class OrderFilterProvider : IFilterProvider
    {
        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            var actionFilters = actionDescriptor.GetFilters().Select(f => new OrderedFilterInfo(f, FilterScope.Action));
            var controllerFilters = actionDescriptor.ControllerDescriptor.GetFilters().Select(f => new OrderedFilterInfo(f, FilterScope.Controller));
            var globalFilters = configuration.Filters.Select(f => new OrderedFilterInfo(f.Instance, FilterScope.Global));

            var filters = globalFilters.Concat(controllerFilters)
                                       .Concat(actionFilters)
                                       .OrderByDescending(f => f.Scope)
                                       .ThenBy(f => f.Position)
                                       .Select(f => new FilterInfo(f.Filter, f.Scope));

            return filters;
        }
    }
}
