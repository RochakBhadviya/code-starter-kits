using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.ServiceLayer.Interface
{
    public interface IConcreteFactory
    {
        /// <summary>
        /// Get an instance of IBowlingGame.
        /// </summary>
        /// <param name="bowlingObject"></param>
        /// <returns></returns>
        IBowlingGame GetBowlingGameInstance(string bowlingObject);
    }
}
