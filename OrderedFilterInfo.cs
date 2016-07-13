using System.Web.Http.Filters;

namespace DevTeam.OrderedFilterAttribute
{
    public class OrderedFilterInfo
    {
        public IFilter Filter { get; set; }
        public FilterScope Scope { get; set; }
        public short Position { get; set; }

        public OrderedFilterInfo(IFilter filter, FilterScope scope)
        {
            IOrderedFilter orderedFilter = null;
            if (filter is IOrderedFilter)
                orderedFilter = filter as IOrderedFilter;

            Filter = filter;
            Scope = orderedFilter != null && orderedFilter.Scope.HasValue ? orderedFilter.Scope.Value : scope;
            Position = orderedFilter != null && orderedFilter.Order.HasValue ? orderedFilter.Order.Value : short.MaxValue;
        }
    }
}
