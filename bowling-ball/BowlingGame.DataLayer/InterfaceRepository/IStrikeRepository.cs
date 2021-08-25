using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.DataLayer.InterfaceRepository
{
    public interface IStrikeRepository<T>: IRepository<T>
    {
        /// <summary>
        /// Execute any method that is related to strike repository.
        /// </summary>
        void ExecuteAnyMethodRelatedToStrikeRepository();
    }
}
