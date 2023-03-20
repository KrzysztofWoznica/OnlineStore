namespace eShop.Application.Interfaces.common.Paging;

public class PagedList<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public IEnumerable<T>? Results { get; set; }
    public int TotalCount { get; set; }
}


