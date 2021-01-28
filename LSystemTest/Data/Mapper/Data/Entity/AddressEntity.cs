using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystemTest.Data.Mapper.Data.Entity
{
    public class AddressEntity
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public CityEntity City { get; set; }

        public static AddressEntity Create()
        {
            return new AddressEntity
            {
                Id = Guid.NewGuid(),
                Description = "123, ABC Avenue",
                City = CityEntity.Create()
            };
        }
    }
}
