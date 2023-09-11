using Filters_Middlewares.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters_Middlewares.Filters;

public class CreateOrderFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        context.ActionArguments.TryGetValue("request", out var request);

        var order = request as CreateOrderRequest;

        if (order is not null)
        {
            if (order.Amount < 10)
            {
                context.Result = new ContentResult
                {
                    Content = "To generate an order it must have a least an amount of 10 units.",
                    StatusCode = StatusCodes.Status400BadRequest
                };

                return;
            }
        }
        else
        {
            context.Result = new ContentResult
            {
                Content = "Order can not be null.",
                StatusCode = StatusCodes.Status400BadRequest
            };

            return;
        }

        await next();
    }
}
