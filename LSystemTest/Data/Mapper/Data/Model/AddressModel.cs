using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystemTest.Data.Mapper.Data.Model
{
    public class AddressModel
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public CityModel City { get; set; }

        public static AddressModel Create()
        {
            return new AddressModel
            {
                Id = Guid.NewGuid(),
                Description = "123, ABC Avenue",
                City = CityModel.Create()
            };
        }
    }
}
