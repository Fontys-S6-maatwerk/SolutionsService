using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolutionsService.Models;
using SolutionsService.Models.RequestModel;

namespace SolutionsService.Converters
{
    public static class ArticleRequestModelConverter
    {
        public static Article ConvertReqModelToDataModel(ArticleRequestModel requestModel)
        {
            Article article = new Article()
            {
                Name = requestModel.Name,
                WeatherExtreme = requestModel.WeatherExtreme,
                HeaderImageURL = requestModel.HeaderImageUrl,
                Description = requestModel.Description,
                AuthorId = requestModel.AuthorId,
                UploadDate = DateTime.Now,
                LastUpdatedTime = DateTime.Now,
                ViewCount = 0,
                Content = requestModel.Content
            };

            //Note: the linked many-to-many data still needs to be processed at a later stage!
            foreach(var sdg in requestModel.SDGIds)
            {
                article.SDGs.Add(new SDGSolution() { SDGId = sdg });
            }

            return article;
        }
    }
}
