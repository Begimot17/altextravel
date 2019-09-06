using AltexTravel.API.DAL.BaseHandlers;
using AltexTravel.API.DAL.Queries.Features.Locations;
using AltexTravel.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Mappers
{
    public static class ValidatedResponseMapper
    {
        public static IActionResult ToAction<TResponce, TResult>(this ValidatedResponse<TResponce> responce,TResult result)  {

            if (responce.IsValid)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestObjectResult(responce.Errors);
        }
        public static IActionResult ToAction<TResponce>(this ValidatedResponse<TResponce> responce)
        {

            if (responce.IsValid)
            {
                return new OkObjectResult(responce.Result);
            }
            return new BadRequestObjectResult(responce.Errors);
        }


    }
}
