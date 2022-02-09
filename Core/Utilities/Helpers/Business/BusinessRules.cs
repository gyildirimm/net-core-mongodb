using Core.Utilities.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.Business
{
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var result in logics)
            {
                if (!result.IsSuccess)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
