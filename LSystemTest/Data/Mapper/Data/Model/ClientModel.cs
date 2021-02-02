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

        public List<int> Li { get; set; }

        public List<PhoneModel> Phones { get; set; }

        //public Dictionary<int, string> Dictio { get; set; }

        //public int[] Array { get; set; }

        public static ClientModel Create()
        {
            return new ClientModel
            {
                Id = Guid.NewGuid(),
                FirstName = "Alexander",
                LastName = "Bell",
                DateAdded = DateTime.Now,
                Address = AddressModel.Create(),
                Li = new List<int> { 1, 2, 3 },
                Phones = new List<PhoneModel> { new PhoneModel { Id = 1, Number = "1234-5678" }, new PhoneModel { Id = 1, Number = "5678-1234" } }
                //Dictio = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" } },
                //Array = new int[] { 1, 2, 3, 4 }
            };
        }
    }
}
