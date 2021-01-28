using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LSystem.Data.Mapper
{
    /// <summary>
    /// List of entities related with a given entity
    /// </summary>
    internal sealed class EntitiesMap
    {
        /// <summary>
        /// Relation between entities that could receive data and their properties.
        /// </summary>
        internal Dictionary<string, List<PropertyMap>> Maps { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="destinationEntityName">Destination entity name</param>
        internal EntitiesMap(string destinationEntityName)
        {
            Maps = new Dictionary<string, List<PropertyMap>>();
            Maps.Add(destinationEntityName, new List<PropertyMap>());
        }

        /// <summary>
        /// Creates a map between source properties and a destination properties
        /// </summary>
        /// <param name="source">Source entity's type</param>
        /// <param name="destination">Destination entity's type</param>
        internal void LoadMap(Type source, Type destination)
        {
            foreach (PropertyInfo sourcePropertyInfo in source.GetProperties())
            {
                PropertyInfo destinationPropertyInfo = destination.GetProperty(sourcePropertyInfo.Name);

                if(destinationPropertyInfo != null)
                    Maps[destination.FullName].Add(new PropertyMap(sourcePropertyInfo.Name, destinationPropertyInfo.Name));
            }
        }

        internal void SetValues<TSource, TDestination>(TSource source, TDestination destination, IMapper mapper)
        {
            List<PropertyMap> propertiesMap = this.Maps[destination.GetType().FullName];

            foreach (PropertyMap propertyMap in propertiesMap)
            {
                propertyMap.SetValueOnDestination<TSource, TDestination>(source, destination, mapper);
            }
        }
    }
}
