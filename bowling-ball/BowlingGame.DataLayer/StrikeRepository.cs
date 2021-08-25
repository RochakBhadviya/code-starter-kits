using BowlingGame.DataLayer.InterfaceRepository;
using BowlingGame.modelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.DataLayer
{
    public class StrikeRepository : RepositoryBase<BowlingScore>, IRepository<BowlingScore>, IStrikeRepository<BowlingScore>
    {
        /// <summary>
        /// Execute any method specific to strike repository.
        /// </summary>
        public void ExecuteAnyMethodRelatedToStrikeRepository()
        {
            throw new NotImplementedException();
        }
    }
}
