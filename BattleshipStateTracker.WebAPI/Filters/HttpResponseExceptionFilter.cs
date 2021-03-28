using BattleshipStateTracker.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BattleshipStateTracker.WebAPI.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is BusinessArgumentException businessArgumentException)
            {
                context.Result = new ObjectResult(businessArgumentException.Message)
                {
                    StatusCode = 400,
                };
            }
            else if (context.Exception is ShipCollisionException shipCollisionException)
            {
                context.Result = new ObjectResult(shipCollisionException.Message)
                {
                    StatusCode = 400,
                };
            }
            else if (context.Exception is BusinessObjectNotFoundException businessObjectNotFoundException)
            {
                context.Result = new ObjectResult(businessObjectNotFoundException.Message)
                {
                    StatusCode = 404,
                };
            }
            else
            {
                context.Result = new ObjectResult("Something went wrong")
                {
                    StatusCode = 500,
                };
            }
            context.ExceptionHandled = true;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
