/*namespace eShop.Contracts.Common
{
    

    public class ServiceResponse
    {
        public IEnumerable<ServiceResponseValidationResult> Errors { get; set; } 
        public ServiceResponseStatus Status { get; set; }
        public bool IsSuccess => Status == ServiceResponseStatus.Success;
                           
        
        public ServiceResponse(ServiceResponseStatus status)
        {
            Errors = new List<ServiceResponseValidationResult>() { };
            Status = status;
        }

        public ServiceResponse()
          : this(ServiceResponseStatus.Success) { }          


    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public T? Entity { get; set; }
              

        public ServiceResponse(T entity)
        {
            Entity = entity;
        }

        public ServiceResponse(T entity, ServiceResponseStatus status)
            : base(status)
        {
            Entity = entity;   
        }

        public ServiceResponse(ServiceResponseStatus status)
            : base(status) { }

    
    }       


}*/
