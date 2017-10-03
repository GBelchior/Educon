using Educon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Educon.Utils
{
    public class GeneralUtils
    {
        public static AgeGroup ConvertToAgeGroup(string AAgeGroup)
        {
            AgeGroup LAgeGroup;
            Enum.TryParse(AAgeGroup, out LAgeGroup);
            return LAgeGroup;

        }

        public static string ConvertToString(ErrorType AEnum)
        {
            return AEnum.ToString();
        }
    }
}