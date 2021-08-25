using BowlingGame.DataLayer.InterfaceRepository;
using BowlingGame.modelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.DataLayer
{
    public class NormalScoreRepository : RepositoryBase<BowlingScore>, IRepository<BowlingScore>, INormalScoreRepository<BowlingScore>
    {
        /// <summary>
        /// Execute any method related to normal score.
        /// </summary>
        public void ExecuteAnyMethodRelatedToNormalScore()
        {
            throw new NotImplementedException();
        }
    }
}
