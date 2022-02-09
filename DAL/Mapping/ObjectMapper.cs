using AutoMapper;
using DAL.Mapping.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BasketProfile>();
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }
}
