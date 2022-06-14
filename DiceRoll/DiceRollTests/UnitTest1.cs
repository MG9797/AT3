using DiceRole;
using System.Collections.Generic;
using Xunit;
namespace DiceRollTests
{
//Unit tests for the two methods in ClGame must be created. As inputs use the following 4 results lists/arrays:
//(1)[2, 7, 3, 11, 2, 2]           Total: 27          Average: 4.50  (2-decimal places)
//(2)[18, 4, 6, 12, 19]           Total: 40          Average: 11.80
//(3)[5] Total: 5            Average: 5
//(4)[] Total: 0            Average: 0
    public class UnitTest1
    {
      
        [Fact]
        public void TotalTest()
        {
            ClGame game = new ClGame();
            game.results = new List<int>() { 2, 7, 3, 11, 2, 2 };
            Assert.Equal(27, game.GetTotal());

            ClGame game2 = new ClGame();
            game2.results = new List<int>() { 18, 4, 6, 12, 19 };
            Assert.Equal(59, game2.GetTotal());

            ClGame game3 = new ClGame();
            game3.results = new List<int>() { 5 };
            
            Assert.Equal(5, game3.GetTotal());
            ClGame game4 = new ClGame();
            Assert.Equal(0, game4.GetTotal());
        }  
        [Fact]
        public void AverageTest()
        {
            ClGame game = new ClGame();
            game.results = new List<int>() { 2, 7, 3, 11, 2, 2 };
            Assert.Equal(4.50, game.GetAverage());

            ClGame game2 = new ClGame();
            game2.results = new List<int>() { 18, 4, 6, 12, 19 };
            Assert.Equal(11.80, game2.GetAverage());

            ClGame game3 = new ClGame();
            game3.results = new List<int>() { 5 };
            Assert.Equal(5, game3.GetAverage());
            ClGame game4 = new ClGame();
            Assert.Equal(0, game4.GetAverage());
        }
    }
}