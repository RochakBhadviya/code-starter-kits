using BowlingGame.DataLayer.InterfaceRepository;
using BowlingGame.modelLayer;
using BowlingGame.ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.ServiceLayer
{
    public class NormalScore : IBowlingGame
    {
        private readonly INormalScoreRepository<BowlingScore> _normalScoreRepository;

        public NormalScore(INormalScoreRepository<BowlingScore> normalScoreRepository)
        {
            _normalScoreRepository = normalScoreRepository;
        }

        public int Frame { get; set; }

        /// <summary>
        /// Execute bowling for normal score.
        /// </summary>
        /// <param name="lastTotal"></param>
        /// <returns></returns>
        public int ExecuteBowling(int lastTotal)
        {
            var score = GetNormalScoreValue(lastTotal);
            return score;
        }

        /// <summary>
        /// Store score to in memory for normal score.
        /// </summary>
        /// <param name="frameId"></param>
        /// <param name="bowlingScore"></param>
        public void StoreScoreToInMemory(int frameId, BowlingScore bowlingScore)
        {
            Frame = frameId;
            _normalScoreRepository.Create(frameId, bowlingScore);
        }

        /// <summary>
        /// Get normal score value.
        /// </summary>
        /// <param name="lastTotal"></param>
        /// <returns></returns>
        private int GetNormalScoreValue(int lastTotal)
        {
            var bowlingScore = _normalScoreRepository.GetById(Frame);
            var normalScore = bowlingScore.FirstThrowScore + bowlingScore.SecondThrowScore + lastTotal;

            return normalScore;
        }
    }
}
