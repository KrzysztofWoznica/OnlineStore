﻿using eShop.Application.Interfaces.common;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
       
        protected IActionResult ActionResultFromServiceResponse<T>(ServiceResponse<T> result) where T : class
            => result.Status switch
            {
                ServiceResponseStatus.Success => Ok(result.Entity),              
                ServiceResponseStatus.NotFound => NotFound(),
                ServiceResponseStatus.ValidationError => UnprocessableEntity(result.Errors),
                ServiceResponseStatus.Conflict => Conflict(result.Errors),
                ServiceResponseStatus.Forbidden => Forbid(),
                _ => NotFound()
            };

        protected IActionResult ActionResultFromServiceResponse(ServiceResponse result)
            => result.Status switch
            {
               ServiceResponseStatus.Success => NoContent(),               
               ServiceResponseStatus.NotFound => NotFound(),
               ServiceResponseStatus.ValidationError => UnprocessableEntity(result.Errors),
               ServiceResponseStatus.Conflict => Conflict(result.Errors),
               ServiceResponseStatus.Forbidden => Forbid(),
               _ => NotFound()
      };


 
    }
}
