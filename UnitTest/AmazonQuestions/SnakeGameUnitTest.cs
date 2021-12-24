using DataStrcutureAlgorithm.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTest.AmazonQuestions
{
    public class SnakeGameUnitTest
    {
        public SnakeGameUnitTest()
        {

        }

        [Fact]
        void TestSnakeGame()
        {
            var obj = new SnakeGame();

            var testSets = new int[][]
            {

                    new int[]{-1, -1, -1, -1, -1, -1},
                    new int[]{-1, -1, -1, -1, -1, -1},
                    new int[]{-1, -1, -1, -1, -1, -1},
                    new int[]{-1, 35, -1, -1, 13, -1},
                    new int[]{-1, -1, -1, -1, -1, -1},
                    new int[]{-1, 15, -1, -1, -1, -1}

            };
            var res = obj.SnakesAndLadders(testSets);

            Assert.Equal(4, res);
        }

        [Fact]
        void TestSnakeGame1()
        {
            var obj = new SnakeGame();

            var testSets = new int[][]
            {
                    new int[]{-1, -1 },
                    new int[]{-1, 3 }
            };

            var res = obj.SnakesAndLadders(testSets);

            Assert.Equal(4, res);
        }
    }
}
