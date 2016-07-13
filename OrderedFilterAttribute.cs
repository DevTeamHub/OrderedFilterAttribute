using System.Web.Http.Filters;

namespace DevTeam.OrderedFilterAttribute
{
    public class OrderedFilterAttribute: ActionFilterAttribute, IOrderedFilter
    {
        public OrderedFilterAttribute()
        {
            Order = 0;
            Scope = FilterScope.Global;
        }

        public short? Order { get; set; }
        public FilterScope? Scope { get; set; }
    }
}
