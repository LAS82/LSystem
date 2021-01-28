using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystemTest.Data.Mapper.Data.Entity
{
    public class ClientEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateAdded { get; set; }

        public AddressEntity Address { get; set; }

        public static ClientEntity Create()
        {
            return new ClientEntity
            {
                Id = Guid.NewGuid(),
                FirstName = "Alexander",
                LastName = "Bell",
                DateAdded = DateTime.Now,
                Address = AddressEntity.Create()
            };
        }
    }
}
