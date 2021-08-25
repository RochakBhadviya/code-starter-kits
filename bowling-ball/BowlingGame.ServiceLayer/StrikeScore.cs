using BowlingGame.DataLayer.InterfaceRepository;
using BowlingGame.modelLayer;
using BowlingGame.ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.ServiceLayer
{
    public class StrikeScore : IBowlingGame
    {
        private readonly IStrikeRepository<BowlingScore> _strikeRepository;

        public StrikeScore(IStrikeRepository<BowlingScore> strikeScoreRepository)
        {
            _strikeRepository = strikeScoreRepository;
        }

        public int Frame { get; set; }

        /// <summary>
        /// Execute bowling for strike score.
        /// </summary>
        /// <param name="lastTotal"></param>
        /// <returns></returns>
        public int ExecuteBowling(int lastTotal)
        {
            var score = GetStrikeScoreValue(lastTotal, Frame, 0);
            return score;
        }

        /// <summary>
        /// Store score to in memory for strike score.
        /// </summary>
        /// <param name="frameId"></param>
        /// <param name="bowlingScore"></param>
        public void StoreScoreToInMemory(int frameId, BowlingScore bowlingScore)
        {
            Frame = frameId;

            _strikeRepository.Create(frameId, bowlingScore);
        }

        /// <summary>
        /// Get strike score total value.
        /// </summary>
        /// <param name="lastTotal"></param>
        /// <param name="frameId"></param>
        /// <param name="totalThrow"></param>
        /// <returns></returns>
        private int GetStrikeScoreValue(int lastTotal, int frameId, int totalThrow = 0)
        {
            var currentStrikeScore = _strikeRepository.GetById(frameId);
            var score = currentStrikeScore.FirstThrowScore + (totalThrow != 2 ? currentStrikeScore.SecondThrowScore : 0) + lastTotal;

            if(IsNextThrowAlsoStrike(currentStrikeScore) && totalThrow < 2)
            {
                return GetStrikeScoreValue(score, frameId + 1, totalThrow + 1);
            }

            return score;
        }

        /// <summary>
        /// Check if score is strike.
        /// </summary>
        /// <param name="nextScore"></param>
        /// <returns></returns>
        private bool IsNextThrowAlsoStrike(BowlingScore nextScore)
        {
            if(nextScore.FirstThrowScore == 10)
            {
                return true;
            }

            return false;
        }
    }
}
