using BowlingGame.DataLayer.InterfaceRepository;
using BowlingGame.modelLayer;
using BowlingGame.ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.ServiceLayer
{
    public class SpareScore: IBowlingGame
    {
        private readonly ISpareRepository<BowlingScore> _spareRepository;

        public SpareScore(ISpareRepository<BowlingScore> spareScoreRepository)
        {
            _spareRepository = spareScoreRepository;
        }

        public int Frame { get; set; }

        /// <summary>
        /// Execute bowling for spare score.
        /// </summary>
        /// <param name="lastTotal"></param>
        /// <returns></returns>
        public int ExecuteBowling(int lastTotal)
        {
            var score = GetSpareScoreValue(lastTotal);
            return score;
        }

        /// <summary>
        /// Store score to in memory for spare score.
        /// </summary>
        /// <param name="frameId"></param>
        /// <param name="bowlingScore"></param>
        public void StoreScoreToInMemory(int frameId, BowlingScore bowlingScore)
        {
            Frame = frameId;

            _spareRepository.Create(frameId, bowlingScore);
        }

        /// <summary>
        /// Get spare total score.
        /// </summary>
        /// <param name="lastTotal"></param>
        /// <returns></returns>
        private int GetSpareScoreValue(int lastTotal)
        {
            var spareScore = _spareRepository.GetById(Frame);
            var nextScore = _spareRepository.GetById(Frame + 1);

            var nextScoreNotNull = nextScore ?? new BowlingScore() { FirstThrowScore = 0, SecondThrowScore = 0};

            var total = spareScore.FirstThrowScore + spareScore.SecondThrowScore + nextScoreNotNull.FirstThrowScore + lastTotal;

            return total;
        }
    }
}
