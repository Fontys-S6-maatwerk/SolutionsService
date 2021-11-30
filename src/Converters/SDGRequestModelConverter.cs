using SolutionsService.Models;
using SolutionsService.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsService.Converters
{
    public class SDGRequestModelConverter
    {
        public static SDG ConvertReqModelToDataModel(SDGRequestModel reqModel)
        {
            SDG dataModel = new SDG()
            {
                Name = reqModel.Name,
                SDGNumber = reqModel.SDGNumber
            };

            return dataModel;
        }
    }
}
