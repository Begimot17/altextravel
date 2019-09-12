using AltexTravel.API.DAL.BaseHandlers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AltexTravel.API.Mappers
{
    public static class ValidatedResponseMapper
    {
        public static IActionResult ToAction<TResponce, TViewModel>(this ValidatedResponse<TResponce> responce, Func<TResponce, TViewModel> viewModelMapper)
        {
            if (responce.IsValid)
            {
                var viewModel = viewModelMapper(responce.Result);
                return new OkObjectResult(viewModel);
            }
            return new BadRequestObjectResult(responce.Errors);
        }

    }
}
