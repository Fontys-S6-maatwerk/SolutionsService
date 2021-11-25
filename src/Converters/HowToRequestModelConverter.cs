using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolutionsService.Models;
using SolutionsService.Models.RequestModel;

namespace SolutionsService.Converters
{
    public class HowToRequestModelConverter
    {
        public static HowTo ConvertReqModelToDataModel(HowToRequestModel requestModel)
        {
            HowTo howTo = new HowTo()
            {
                Name = requestModel.Name,
                WeatherExtreme = requestModel.WeatherExtreme,
                HeaderImageURL = requestModel.HeaderImageUrl,
                Description = requestModel.Description,
                AuthorId = requestModel.AuthorId,
                UploadDate = DateTime.Now,
                LastUpdatedTime = DateTime.Now,
                ViewCount = 0
            };

            //Note: the linked many-to-many data still needs to be processed at a later stage!
            foreach (var sdg in requestModel.SDGIds)
            {
                howTo.SDGs.Add(new SDGSolution() { SDGId = sdg });
            }

            foreach(var tool in requestModel.Tools)
            {
                howTo.Tools.Add(new Tool() { Name = tool });
            }

            foreach(var material in requestModel.Materials)
            {
                howTo.Materials.Add(new Material() { Name = material });
            }

            foreach(var step in requestModel.Steps)
            {
                howTo.Steps.Add(new Step() { CoverImage = step.CoverImage, Description = step.Description });
            }

            return howTo;
        }
    }
}
