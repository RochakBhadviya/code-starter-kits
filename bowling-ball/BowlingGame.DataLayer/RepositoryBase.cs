using BowlingGame.DataLayer.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.DataLayer
{
    public class RepositoryBase<T> : IRepository<T>
    {
        public RepositoryBase()
        {
            //Use dependency injection for db context or other object.
        }

        /// <summary>
        /// Insert new entity in the memory.
        /// </summary>
        /// <param name="frameId"></param>
        /// <param name="entity"></param>
        public void Create(int frameId, T entity)
        {
            MemoryCacheStorage.GetInstance.InsertIntoCache(frameId, entity);
        }

        /// <summary>
        /// Get all entities for all frames.
        /// </summary>
        /// <returns></returns>
        public T GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get frame detail by frame id.
        /// </summary>
        /// <param name="frameId"></param>
        /// <returns></returns>
        public T GetById(int frameId)
        {
            return MemoryCacheStorage.GetInstance.GetBowlingScore<T>(frameId);
        }
    }
}
