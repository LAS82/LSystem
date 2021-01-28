using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystemTest.Data.Mapper.Data.Model
{
    public class CityModel
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public static CityModel Create()
        {
            return new CityModel { 
                Id = "SP",
                Description = "São Paulo"
            };
        }
    }
}
