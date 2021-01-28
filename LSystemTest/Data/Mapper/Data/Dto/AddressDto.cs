using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystemTest.Data.Mapper.Data.Dto
{
    public class AddressDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public CityDto City { get; set; }

        public static AddressDto Create()
        {
            return new AddressDto
            {
                Id = Guid.NewGuid(),
                Description = "123, ABC Avenue",
                City = CityDto.Create()
            };
        }
    }
}
