﻿using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.WebApi
{
    public class CheckOrderFilterAttribute : ActionFilterAttribute
    {


        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var dbContext = context.HttpContext.RequestServices.GetRequiredService<IDbContext>();
            var currentUserService = context.HttpContext.RequestServices.GetRequiredService<ICurrentUserService>();
            var id = (int)context.ActionArguments["id"];

            var count = await dbContext.Orders.CountAsync(x => x.UserEmail == currentUserService.Email && x.Id == id);
            if (count != 1)
            {
                context.Result = new NotFoundResult();
                return;
            }
            await base.OnActionExecutionAsync(context, next);
        }
    }
}
