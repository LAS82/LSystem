using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystemTest.Data.Mapper.Data.Entity
{
    public class CityEntity
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public static CityEntity Create()
        {
            return new CityEntity
            { 
                Id = "SP",
                Description = "São Paulo"
            };
        }
    }
}
