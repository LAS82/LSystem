using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystemTest.Data.Mapper.Data.Dto
{
    public class ClientDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateAdded { get; set; }

        public AddressDto Address { get; set; }

        public static ClientDto Create()
        {
            return new ClientDto
            {
                Id = Guid.NewGuid(),
                FirstName = "Alexander",
                LastName = "Bell",
                DateAdded = DateTime.Now,
                Address = AddressDto.Create()
            };
        }
    }
}
