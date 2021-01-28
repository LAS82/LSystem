using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LSystem.Data.Mapper
{
    /// <summary>
    /// Maps entities to make it easier to transport data.
    /// </summary>
    public sealed class Mapper : IMapper
    {

        /// <summary>
        /// List of mapped entities
        /// </summary>
        private static Dictionary<string, List<EntitiesMap>> Maps { get; set; }

        /// <summary>
        /// Used to guarantee the unique Maps' creation 
        /// </summary>
        private object ToLock => new object();

        /// <summary>
        /// Constructor
        /// </summary>
        public Mapper()
        {
            lock (ToLock)
            {
                if (Maps == null)
                    Maps = new Dictionary<string, List<EntitiesMap>>();
            }
        }

        /// <summary>
        /// Creates a map between entities
        /// </summary>
        /// <param name="source">Source entity</param>
        /// <param name="destination">Destination entity</param>
        /// <returns>This Mapper object</returns>
        public IMapper CreateMap(Type source, Type destination)
        {
            if (!Maps.ContainsKey(source.FullName))
            {
                Maps.Add(source.FullName, new List<EntitiesMap>());
            }
            EntitiesMap entitiesMap = new EntitiesMap(destination.FullName);

            Maps[source.FullName].Add(entitiesMap);

            entitiesMap.LoadMap(source, destination);

            return this;
        }

        /// <summary>
        /// Creates a map between entities
        /// </summary>
        /// <param name="source">Source entity</param>
        /// <param name="destination">Destination entity</param>
        /// <returns>Task</returns>
        public async Task CreateMapAsync(Type source, Type destination)
        {
            await Task.Factory.StartNew(() => {
                CreateMap(source, destination);
            });
        }

        /// <summary>
        /// Sets destination with source data.
        /// </summary>
        /// <typeparam name="TSource">Source Datatype</typeparam>
        /// <typeparam name="TDestination">Destination datatype</typeparam>
        /// <param name="source">Source data</param>
        /// <returns>Destination object filled</returns>
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            if (!Maps.ContainsKey(source.GetType().FullName))
                return default;

            List<EntitiesMap> entitiesMapList = Maps[source.GetType().FullName];

            TDestination destination = Activator.CreateInstance<TDestination>();

            EntitiesMap entityMap = entitiesMapList.FirstOrDefault(x => x.Maps.ContainsKey(destination.GetType().FullName));
            entityMap.SetValues(source, destination, this);

            return destination;
        }

        /// <summary>
        /// Sets destination with source data.
        /// </summary>
        /// <typeparam name="TSource">Source Datatype</typeparam>
        /// <typeparam name="TDestination">Destination datatype</typeparam>
        /// <param name="source">Source data</param>
        /// <returns>Destination object filled</returns>
        public async Task<TDestination> MapAsync<TSource, TDestination>(TSource source)
        {
            return await Task.Factory.StartNew(() => {
                return Map<TSource, TDestination>(source);
            });
        }
    }
}
