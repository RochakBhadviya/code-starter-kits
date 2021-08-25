using BowlingGame.DataLayer;
using BowlingGame.ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.ServiceLayer
{
    public class ConcreteFactory : IConcreteFactory
    {
        /// <summary>
        /// Get instance of IBowlingGame.
        /// </summary>
        /// <param name="bowlingObject"></param>
        /// <returns></returns>
        public IBowlingGame GetBowlingGameInstance(string bowlingObject)
        {
            switch(bowlingObject)
            {
                case "Strike":
                    return new StrikeScore(new StrikeRepository());
                case "Spare":
                    return new SpareScore(new SpareRepository());
                default:
                    return new NormalScore(new NormalScoreRepository());
            }
        }
    }
}
