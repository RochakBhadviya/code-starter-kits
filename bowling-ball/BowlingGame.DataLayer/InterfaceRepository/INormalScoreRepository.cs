using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.DataLayer.InterfaceRepository
{
    public interface INormalScoreRepository<T> : IRepository<T> 
    {
        /// <summary>
        /// Execute any method related to normal score.
        /// </summary>
        void ExecuteAnyMethodRelatedToNormalScore();
    }
}
