using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LSystem.Data.Mapper
{
    /// <summary>
    /// Contains the source and destination properties
    /// </summary>
    internal sealed class PropertyMap
    {
        /// <summary>
        /// Source property
        /// </summary>
        internal string Source { get; private set; }

        /// <summary>
        /// Destination property
        /// </summary>
        internal string Destination { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">Source type</param>
        /// <param name="destination">Destination type</param>
        internal PropertyMap(string source, string destination)
        {
            Source = source;
            Destination = destination;
        }

        /// <summary>
        /// Sets a value on destination
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        /// <param name="mapper">Mapper used to call the map method to find and set reference type data</param>
        internal void SetValueOnDestination<TSource, TDestination>(TSource source, TDestination destination, IMapper mapper)
        {
            Type sourcePropertyType = source.GetType().GetProperty(Source).GetValue(source).GetType();

            if(sourcePropertyType.GetInterfaces().FirstOrDefault(i => i.Name == "IEnumerable") != null && sourcePropertyType != typeof(string))
                this.SetValuesForCollectionType(source, destination, mapper);
            else if (sourcePropertyType.IsValueType || sourcePropertyType == typeof(string))
                this.SetValueForValueType(source, destination);
            else
                this.SetValueForReferenceType(source, destination, mapper);
        }

        /// <summary>
        /// Sets a value type value
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        private void SetValueForValueType<TSource, TDestination>(TSource source, TDestination destination)
        {
            PropertyInfo destinationProperty = destination.GetType().GetProperty(Destination);
            object sourceValue = source.GetType().GetProperty(Source).GetValue(source);

            destinationProperty.SetValue(destination, sourceValue);
        }

        /// <summary>
        /// Sets a reference type value
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        /// <param name="mapper">Mapper used to call the map method to find and set reference type data</param>
        private void SetValueForReferenceType<TSource, TDestination>(TSource source, TDestination destination, IMapper mapper)
        {
            PropertyInfo destinationProperty = destination.GetType().GetProperty(Destination);
            object sourceValue = source.GetType().GetProperty(Source).GetValue(source);
            object value = this.ExecMapMethod(mapper, destinationProperty, sourceValue);

            destinationProperty.SetValue(destination, value);
        }

        /// <summary>
        /// Sets collection values
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        /// <param name="mapper">Mapper used to call the map method to find and set reference type data</param>
        private void SetValuesForCollectionType<TSource, TDestination>(TSource source, TDestination destination, IMapper mapper)
        {

            PropertyInfo destinationProperty = destination.GetType().GetProperty(Destination);

            Type destinationType = destination.GetType().GetProperty(Destination).PropertyType;

            if (destinationType.IsArray)
            {
                return;
            }
            else if (destinationType.GetInterfaces().FirstOrDefault(x => x.Name == "IDictionary") != null)
            {
            }
            else if (destinationType.GetInterfaces().FirstOrDefault(x => x.Name == "IList") != null)
            {

                if (destinationType.GenericTypeArguments.FirstOrDefault().IsValueType || destinationType.GenericTypeArguments.FirstOrDefault() == typeof(string))
                {
                    var destinationListInstance = Activator.CreateInstance(destinationType) as System.Collections.IList;

                    System.Collections.IList sourceList = source.GetType().GetProperty(Source).GetValue(source) as System.Collections.IList;

                    foreach (var sourceItem in sourceList)
                        destinationListInstance.Add(sourceItem);

                    destination.GetType().GetProperty(Destination).SetValue(destination, destinationListInstance);
                }
                else if (!destinationType.GenericTypeArguments.FirstOrDefault().IsValueType)
                {
                    var destinationListInstance = Activator.CreateInstance(destinationType) as System.Collections.IList;

                    System.Collections.IList sourceList = source.GetType().GetProperty(Source).GetValue(source) as System.Collections.IList;

                    foreach (var sourceItem in sourceList)
                    {
                        var destinationInstance = ExecMapMethod(mapper, destinationListInstance.GetType().GenericTypeArguments.FirstOrDefault(), sourceItem);
                        destinationListInstance.Add(destinationInstance);
                    }

                    destination.GetType().GetProperty(Destination).SetValue(destination, destinationListInstance);
                }
            }

        }

        /// <summary>
        /// Executes the map method
        /// </summary>
        /// <param name="mapper">Mapper that contains the map method</param>
        /// <param name="destinationProperty">Destination property</param>
        /// <param name="sourceValue">Source value</param>
        /// <returns>The object filled</returns>
        private object ExecMapMethod(IMapper mapper, PropertyInfo destinationProperty, object sourceValue)
        {
            Type destinationPropertyType = destinationProperty.PropertyType;
            return ExecMapMethod(mapper, destinationPropertyType, sourceValue);
        }

        /// <summary>
        /// Executes the map method
        /// </summary>
        /// <param name="mapper">Mapper that contains the map method</param>
        /// <param name="destinationType">Destination type</param>
        /// <param name="sourceValue">Source value</param>
        /// <returns>The object filled</returns>
        private object ExecMapMethod(IMapper mapper, Type destinationType, object sourceValue)
        {
            Type mapperType = mapper.GetType();
            Type sourceType = sourceValue.GetType();

            MethodInfo mapMethod = mapperType.GetMethod("Map").MakeGenericMethod(new Type[] { sourceType, destinationType });

            return mapMethod.Invoke(mapper, new object[] { sourceValue });
        }
    }
}
