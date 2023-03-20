using Microsoft.AspNetCore.Mvc;


namespace eShop.Application.Interfaces.common.Paging
{
    public class FromQueryParameters
    {
        [FromQuery(Name = "pageNumber")]
        public int? PageNumber { get; set; }

        [FromQuery(Name = "pageSize")]
        public int? PageSize { get; set; }
    }
}
