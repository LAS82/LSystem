using LSystem.Data.Mapper;
using LSystemTest.Data.Mapper.Data.Entity;
using LSystemTest.Data.Mapper.Data.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace LSystemTest.Data.Mapper
{
    [TestClass]
    public class MapperTest
    {
        private LSystem.Data.Mapper.IMapper EntitiesMapper = new LSystem.Data.Mapper.Mapper();

        [TestMethod]
        public void Map()
        {
            CreateMaps();

            ClientModel model = ClientModel.Create();

            ClientEntity entity = EntitiesMapper.Map<ClientModel, ClientEntity>(model);
            ClientModel model2 = EntitiesMapper.Map<ClientEntity, ClientModel>(entity);

            Assert.AreEqual(model.Id, entity.Id);
            Assert.AreEqual(model.FirstName, entity.FirstName);
            Assert.AreEqual(model.LastName, entity.LastName);
            Assert.AreEqual(model.DateAdded, entity.DateAdded);
            Assert.AreEqual(model.Address.Id, entity.Address.Id);
            Assert.AreEqual(model.Address.Description, entity.Address.Description);
            Assert.AreEqual(model.Address.City.Id, entity.Address.City.Id);
            Assert.AreEqual(model.Address.City.Description, entity.Address.City.Description);

            Assert.AreEqual(entity.Id, model2.Id);
            Assert.AreEqual(entity.FirstName, model2.FirstName);
            Assert.AreEqual(entity.LastName, model2.LastName);
            Assert.AreEqual(entity.DateAdded, model2.DateAdded);
            Assert.AreEqual(entity.Address.Id, model2.Address.Id);
            Assert.AreEqual(entity.Address.Description, model2.Address.Description);
            Assert.AreEqual(entity.Address.City.Id, model2.Address.City.Id);
            Assert.AreEqual(entity.Address.City.Description, model2.Address.City.Description);
        }

        [TestMethod]
        public async Task MapAsync()
        {
            await CreateMapsAsync();

            ClientModel model = ClientModel.Create();

            ClientEntity entity = await EntitiesMapper.MapAsync<ClientModel, ClientEntity>(model);
            ClientModel model2 = await EntitiesMapper.MapAsync<ClientEntity, ClientModel>(entity);

            Assert.AreEqual(model.Id, entity.Id);
            Assert.AreEqual(model.FirstName, entity.FirstName);
            Assert.AreEqual(model.LastName, entity.LastName);
            Assert.AreEqual(model.DateAdded, entity.DateAdded);
            Assert.AreEqual(model.Address.Id, entity.Address.Id);
            Assert.AreEqual(model.Address.Description, entity.Address.Description);
            Assert.AreEqual(model.Address.City.Id, entity.Address.City.Id);
            Assert.AreEqual(model.Address.City.Description, entity.Address.City.Description);

            Assert.AreEqual(entity.Id, model2.Id);
            Assert.AreEqual(entity.FirstName, model2.FirstName);
            Assert.AreEqual(entity.LastName, model2.LastName);
            Assert.AreEqual(entity.DateAdded, model2.DateAdded);
            Assert.AreEqual(entity.Address.Id, model2.Address.Id);
            Assert.AreEqual(entity.Address.Description, model2.Address.Description);
            Assert.AreEqual(entity.Address.City.Id, model2.Address.City.Id);
            Assert.AreEqual(entity.Address.City.Description, model2.Address.City.Description);
        }

        private void CreateMaps()
        {
            EntitiesMapper
                .CreateMap(typeof(ClientModel), typeof(ClientEntity))
                .CreateMap(typeof(ClientEntity), typeof(ClientModel))
                .CreateMap(typeof(AddressModel), typeof(AddressEntity))
                .CreateMap(typeof(AddressEntity), typeof(AddressModel))
                .CreateMap(typeof(CityModel), typeof(CityEntity))
                .CreateMap(typeof(CityEntity), typeof(CityModel))
                .CreateMap(typeof(PhoneModel), typeof(PhoneEntity))
                .CreateMap(typeof(PhoneEntity), typeof(PhoneModel));
        }

        private async Task CreateMapsAsync()
        {
            await EntitiesMapper.CreateMapAsync(typeof(ClientModel), typeof(ClientEntity));
            await EntitiesMapper.CreateMapAsync(typeof(ClientEntity), typeof(ClientModel));
            await EntitiesMapper.CreateMapAsync(typeof(AddressModel), typeof(AddressEntity));
            await EntitiesMapper.CreateMapAsync(typeof(AddressEntity), typeof(AddressModel));
            await EntitiesMapper.CreateMapAsync(typeof(CityModel), typeof(CityEntity));
            await EntitiesMapper.CreateMapAsync(typeof(CityEntity), typeof(CityModel));
        }
    }
}
