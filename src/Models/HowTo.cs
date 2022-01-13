using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SolutionsService.Models.ResponseModels;
using SolutionsService.Logic;

namespace SolutionsService.Models
{
    public class HowTo : Solution
    {
        public HowTo()
        {
            this.SDGs = new HashSet<SDGSolution>();
            this.Likes = new HashSet<Like>();
            this.Materials = new HashSet<Material>();
            this.Tools = new HashSet<Tool>();
            this.Steps = new HashSet<Step>();
        }

        public string Introduction { get; set; }
        public string Difficulty { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
        public virtual ICollection<Tool> Tools { get; set; }
        public virtual ICollection<Step> Steps { get; set; }

        public override HowToResponse ConvertToResponseModel()
        {
            return ResponseModelBuilder.BuildHowToResponse(this);
        }

        public override bool Equals(object obj)
        {
            return obj is HowTo to &&
                   base.Equals(obj) &&
                   Id.Equals(to.Id) &&
                   Name == to.Name &&
                   WeatherExtreme == to.WeatherExtreme &&
                   HeaderImageURL == to.HeaderImageURL &&
                   Description == to.Description &&
                   AuthorId.Equals(to.AuthorId) &&
                   UploadDate == to.UploadDate &&
                   LastUpdatedTime == to.LastUpdatedTime &&
                   ViewCount == to.ViewCount &&
                   EqualityComparer<ICollection<SDGSolution>>.Default.Equals(SDGs, to.SDGs) &&
                   EqualityComparer<ICollection<Like>>.Default.Equals(Likes, to.Likes) &&
                   Introduction == to.Introduction &&
                   Difficulty == to.Difficulty &&
                   EqualityComparer<ICollection<Material>>.Default.Equals(Materials, to.Materials) &&
                   EqualityComparer<ICollection<Tool>>.Default.Equals(Tools, to.Tools) &&
                   EqualityComparer<ICollection<Step>>.Default.Equals(Steps, to.Steps);
        }
    }
}
