using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolutionsService.Models;
using SolutionsService.Models.RequestModel;

namespace SolutionsService.Converters
{
    public static class StepRequestModelConverter
    {
        public static Step ConvertReqModelToDataModel(StepRequestModel requestModel)
        {
            Step dataModel = new Step()
            {
                CoverImage = requestModel.CoverImage,
                Description = requestModel.Description
            };

            return dataModel;
        }
    }
}
