using AltexTravel.API.DAL.BaseHandlers;
using Microsoft.AspNetCore.Mvc;

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
