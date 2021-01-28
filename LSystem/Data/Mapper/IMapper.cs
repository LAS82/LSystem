using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystem.Data.Mapper
{
    public interface IMapper
    {
        /// <summary>
        /// Creates a map between entities
        /// </summary>
        /// <param name="source">Source entity</param>
        /// <param name="destination">Destination entity</param>
        /// <returns>This Mapper object</returns>
        IMapper CreateMap(Type source, Type destination);

        /// <summary>
        /// Sets destination with source data.
        /// </summary>
        /// <typeparam name="TSource">Source Datatype</typeparam>
        /// <typeparam name="TDestination">Destination datatype</typeparam>
        /// <param name="source">Source data</param>
        /// <returns>Destination object filled</returns>
        TDestination Map<TSource, TDestination>(TSource source);

        /// <summary>
        /// Creates a map between entities
        /// </summary>
        /// <param name="source">Source entity</param>
        /// <param name="destination">Destination entity</param>
        /// <returns>Task</returns>
        Task CreateMapAsync(Type source, Type destination);

        /// <summary>
        /// Sets destination with source data.
        /// </summary>
        /// <typeparam name="TSource">Source Datatype</typeparam>
        /// <typeparam name="TDestination">Destination datatype</typeparam>
        /// <param name="source">Source data</param>
        /// <returns>Destination object filled</returns>
        Task<TDestination> MapAsync<TSource, TDestination>(TSource source);
    }
}
