using System.Web.Http.Filters;

namespace DevTeam.OrderedFilterAttribute
{
    public interface IOrderedFilter
    {
        short? Order { get; set; }
        FilterScope? Scope { get; set; }
    }
}
