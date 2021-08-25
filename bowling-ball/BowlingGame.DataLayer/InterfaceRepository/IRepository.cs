using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.DataLayer.InterfaceRepository
{
    /// <summary>
    /// Generic repository interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Create a new entry in memory.
        /// </summary>
        /// <param name="frameId"></param>
        /// <param name="entity"></param>
        void Create(int frameId, T entity);

        /// <summary>
        /// Get frame details by frame id.
        /// </summary>
        /// <param name="frameId"></param>
        /// <returns></returns>
        T GetById(int frameId);

        /// <summary>
        /// Get all frame details.
        /// </summary>
        /// <returns></returns>
        T GetAll();
    }
}
