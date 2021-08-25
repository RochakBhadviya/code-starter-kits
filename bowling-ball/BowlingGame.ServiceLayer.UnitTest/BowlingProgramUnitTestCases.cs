using System;
using Xunit;

namespace BowlingGame.ServiceLayer.UnitTest
{
    public class BowlingProgramUnitTestCases
    {
        private readonly MainExecution _mainExecution;

        public BowlingProgramUnitTestCases()
        {
            _mainExecution = new MainExecution(new ConcreteFactory());
        }

        [Fact]
        public void ShouldExecuteFramesAndReturnTotal()
        {
            var roleResult = new int[,] { { 3, 1 }, { 10, 0 }, { 10, 0 }, { 7, 1 } };

            _mainExecution.SaveObjetForExecutionForAllFrames(roleResult);
            var response = _mainExecution.GetTotalOfTheBowlingFrame();

            Assert.NotNull(response);
            Assert.Equal(4, response[0]);
            Assert.Equal(57, response[response.Length - 1]);
        }

        [Fact]
        public void ShouldExecuteFramesAndReturnPerfectGameResult()
        {
            var roleResult = new int[,] { { 10, 0 }, { 10, 0 }, { 10, 0 }, { 10, 0 }, { 10, 0 }, { 10, 0 }, { 10, 0 }, { 10, 0 }, { 10, 0 }, { 10, 0 }, { 10, 0 }, { 10, 0 } };

            _mainExecution.SaveObjetForExecutionForAllFrames(roleResult);
            var response = _mainExecution.GetTotalOfTheBowlingFrame();

            Assert.NotNull(response);
            Assert.Equal(300, response[response.Length - 1]);
        }

        [Fact]
        public void ShouldExecuteFramesAndReturnPerfectGameResultOnReverseOrder()
        {
            var roleResult = new int[,] { { 0, 10 }, { 0, 10 }, { 0, 10 }, { 0, 10 }, { 0, 10 }, { 0, 10 }, { 0, 10 }, { 0, 10 }, { 0, 10 }, { 0, 10 }, { 0, 10 }, { 0, 10 } };

            _mainExecution.SaveObjetForExecutionForAllFrames(roleResult);
            var response = _mainExecution.GetTotalOfTheBowlingFrame();

            Assert.NotNull(response);
            Assert.Equal(100, response[response.Length - 1]);
        }

        [Fact]
        public void ShouldExecuteFramesAndReturnSpareResult()
        {
            var roleResult = new int[,] { { 9, 1 }, { 9, 1 }, { 9, 1 }, { 9, 1 }, { 9, 1 }, { 9, 1 }, { 9, 1 }, { 9, 1 }, { 9, 1 }, { 9, 1 }, { 9, 1 } };

            _mainExecution.SaveObjetForExecutionForAllFrames(roleResult);
            var response = _mainExecution.GetTotalOfTheBowlingFrame();

            Assert.NotNull(response);
            Assert.Equal(190, response[response.Length - 1]);
        }

        [Fact]
        public void ShouldExecuteFramesAndReturnSpareResultAsGivenInExample()
        {
            var roleResult = new int[,] { { 10, 0 }, { 9, 1 }, { 5, 5 }, { 7, 2 }, { 10, 0 }, { 10, 0 }, { 10, 0 }, { 9, 0 }, { 8, 2 }, { 9, 1 }, { 10, 0 } };

            _mainExecution.SaveObjetForExecutionForAllFrames(roleResult);
            var response = _mainExecution.GetTotalOfTheBowlingFrame();

            Assert.NotNull(response);
            Assert.Equal(187, response[response.Length - 1]);
        }
    }
}
