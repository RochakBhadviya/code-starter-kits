using BowlingGame.modelLayer;


namespace BowlingGame.ServiceLayer.Interface
{
    /// <summary>
    /// IBowlingGame interface.
    /// </summary>
    public interface IBowlingGame
    {
        /// <summary>
        /// Frame Number.
        /// </summary>
        int Frame { get; set; }

        /// <summary>
        /// Execute bowling.
        /// </summary>
        /// <param name="lastTotal"></param>
        /// <returns></returns>
        int ExecuteBowling(int lastTotal);

        /// <summary>
        /// Store score to in memory.
        /// </summary>
        /// <param name="frameId"></param>
        /// <param name="bowlingScore"></param>
        void StoreScoreToInMemory(int frameId, BowlingScore bowlingScore);
    }
}
