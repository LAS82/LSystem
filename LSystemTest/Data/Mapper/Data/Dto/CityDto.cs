using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystemTest.Data.Mapper.Data.Dto
{
    public class CityDto
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public static CityDto Create()
        {
            return new CityDto
            { 
                Id = "SP",
                Description = "São Paulo"
            };
        }
    }
}
