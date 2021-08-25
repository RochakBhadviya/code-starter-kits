using BowlingGame.DataLayer.InterfaceRepository;
using BowlingGame.modelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.DataLayer
{
    public class SpareRepository : RepositoryBase<BowlingScore>, IRepository<BowlingScore>, ISpareRepository<BowlingScore>
    {
        /// <summary>
        /// Execute any method specific to spare repository.
        /// </summary>
        public void ExecuteAnyMethodRelatedToSpareRepository()
        {
            throw new NotImplementedException();
        }
    }
}
