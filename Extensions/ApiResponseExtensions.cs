using ctrmmvp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ctrmmvp.Extensions
{
    public static class ApiResponseExtensions
    {
        public static IEnumerable<BadRequestModel> GetError(this ActionContext actionContext)
        {
            return actionContext.ModelState
                .Where(modelError => modelError.Value.Errors.Count > 0)
                .Select(modelError => new BadRequestModel
                {
                    Field = modelError.Key,
                    ErrorMessage = modelError.Value.Errors.FirstOrDefault()?.ErrorMessage
                });
        }
    }
}