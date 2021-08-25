using BowlingGame.modelLayer;
using BowlingGame.ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.ServiceLayer
{
    public class MainExecution
    {
        private const int MaxInFrame = 10;
        private const string Strike = "Strike";
        private const string Spare = "Spare";
        private const string NormalScore = "NormalScore";

        private readonly IConcreteFactory _factory;
        private readonly IDictionary<int, IBowlingGame> keyValuePairs = new Dictionary<int, IBowlingGame>();

        public MainExecution(IConcreteFactory concreteFactory)
        {
            _factory = concreteFactory;
        }

        /// <summary>
        /// Save object for execution at the end.
        /// </summary>
        /// <param name="frameId"></param>
        /// <param name="bowlingScore"></param>
        public void SaveObjectForExecution(int frameId, BowlingScore bowlingScore)
        {
            var instance = GetExecutionBowlingScoreType(bowlingScore);

            instance.Frame = frameId;

            instance.StoreScoreToInMemory(frameId, bowlingScore);
            SaveObjectStateInDictionary(frameId, instance);
        }

        /// <summary>
        /// Get total of the bowling frame.
        /// </summary>
        /// <returns></returns>
        public int[] GetTotalOfTheBowlingFrame()
        {
            int[] arrayOfTotal = new int[keyValuePairs.Count];

            int index = 0;
            foreach (var item in keyValuePairs)
            {
                var value = (item.Value as IBowlingGame).ExecuteBowling(index == 0 ? 0 : arrayOfTotal[index - 1]);
                arrayOfTotal.SetValue(value, index);

                index++;
            }

            return arrayOfTotal;
        }

        /// <summary>
        /// Save object for execution for all frames.
        /// </summary>
        /// <param name="twoDimensionArray"></param>
        public void SaveObjetForExecutionForAllFrames(int[,] twoDimensionArray)
        {
            for (int i = 0; i < twoDimensionArray.Length / 2; i++)
            {
                var bowlingScore = new BowlingScore();
                bowlingScore.FirstThrowScore = twoDimensionArray[i, 0];
                bowlingScore.SecondThrowScore = twoDimensionArray[i, 1];

                SaveObjectForExecution(i + 1, bowlingScore);
            }
        }

        /// <summary>
        /// Get IBowlingGame instance.
        /// </summary>
        /// <param name="bowlingScore"></param>
        /// <returns></returns>
        private IBowlingGame GetExecutionBowlingScoreType(BowlingScore bowlingScore)
        {
            if(bowlingScore.FirstThrowScore == MaxInFrame || bowlingScore.SecondThrowScore == MaxInFrame)
            {
                return _factory.GetBowlingGameInstance(Strike);
            }
            else if(bowlingScore.FirstThrowScore + bowlingScore.SecondThrowScore == MaxInFrame)
            {
                return _factory.GetBowlingGameInstance(Spare);
            }
            else
            {
                return _factory.GetBowlingGameInstance(NormalScore);
            }
        }

        /// <summary>
        /// Save object to dictionary.
        /// </summary>
        /// <param name="framId"></param>
        /// <param name="bowlingGame"></param>
        private void SaveObjectStateInDictionary(int framId, IBowlingGame bowlingGame)
        {
            if(framId <= 10)
            {
                if(!keyValuePairs.TryGetValue(framId, out IBowlingGame bowlingGame1))
                {
                    keyValuePairs.TryAdd(framId, bowlingGame);
                }
            }
        }
    }
}
