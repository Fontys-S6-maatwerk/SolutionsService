using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolutionsService.Models;
using SolutionsService.Models.ResponseModels;

namespace SolutionsService.Logic
{
    public static class ResponseModelBuilder
    {
        private static SolutionResponse BuildBaseSolutionResponse(Solution solution, SolutionResponse response)
        {
            response.AuthorId = solution.AuthorId;
            response.Description = solution.Description;
            response.HeaderImageURL = solution.HeaderImageURL;
            response.Id = solution.Id;
            response.LastUpdatedTime = solution.LastUpdatedTime;
            response.Likes = solution.Likes.Count();
            response.Name = solution.Name;
            response.SDGs = solution.SDGs
                .Select(x => BuildSDGResponse(x.SDG))
                .ToList();
            response.UploadDate = solution.UploadDate;
            response.ViewCount = solution.ViewCount;
            response.WeatherExtreme = solution.WeatherExtreme;

            return response;
        }

        public static ArticleResponse BuildArticleResponse(Article solution)
        {
            ArticleResponse response = (ArticleResponse) BuildBaseSolutionResponse(solution,new ArticleResponse());
            response.Content = solution.Content;

            return response;
        }

        public static HowToResponse BuildHowToResponse(HowTo solution)
        {
            HowToResponse response = (HowToResponse) BuildBaseSolutionResponse(solution, new HowToResponse());
            response.Difficulty = solution.Difficulty;
            response.Introduction = solution.Introduction;
            response.Materials = solution.Materials.Select(x => x.Name).ToList();
            response.Tools = solution.Materials.Select(x => x.Name).ToList();
            response.Steps = solution.Steps
                .Select(x => new StepResponse { Description = x.Description, CoverImage = x.CoverImage })
                .ToList();

            return response;
        }

        public static SDGResponse BuildSDGResponse(SDG sdg)
        {
            return new SDGResponse()
            {
                Id = sdg.Id,
                Name = sdg.Name,
                SDGNumber = sdg.SDGNumber
            };
        }
    }
}
