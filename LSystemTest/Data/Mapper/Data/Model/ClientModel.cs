using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystemTest.Data.Mapper.Data.Model
{
    public class ClientModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateAdded { get; set; }

        public AddressModel Address { get; set; }

        public static ClientModel Create()
        {
            return new ClientModel
            {
                Id = Guid.NewGuid(),
                FirstName = "Alexander",
                LastName = "Bell",
                DateAdded = DateTime.Now,
                Address = AddressModel.Create()
            };
        }
    }
}
