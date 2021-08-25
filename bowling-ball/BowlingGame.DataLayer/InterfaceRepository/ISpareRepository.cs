using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.DataLayer.InterfaceRepository
{
    public interface ISpareRepository<T> : IRepository<T>
    {
        /// <summary>
        /// Execute any method that is related to spare repository.
        /// </summary>
        void ExecuteAnyMethodRelatedToSpareRepository();
    }
}
