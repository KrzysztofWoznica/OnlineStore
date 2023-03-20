using eShop.Application.Common.Paging;


namespace eShop.Infrastructure.Persistence.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> GetPage<T>(this IQueryable<T> queryable, PagingParameters parameters)
            => queryable.Skip(parameters.PageSize * (parameters.PageNumber - 1)).Take(parameters.PageSize);       
    }
}
