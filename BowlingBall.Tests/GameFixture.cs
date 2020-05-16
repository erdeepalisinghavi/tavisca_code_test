using System;
using NUnit.Framework;

namespace BowlingBall.Tests
{
    [TestFixture]
    public class GameFixture
    {
        [Test]
        public void Gutter_game_score_should_be_zero_test()
        {
            var game = new Game();
            for(int i=0;i<10;i++)
            {
                game.CreateFrame(0);
            }
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void Game_with_all_frame_score_one_test()
        {
            var game = new Game();
            for (int i = 0; i < 10; i++)
            {
                game.CreateFrame(1);
            }
            Assert.AreEqual(10, game.GetScore());
        }

        [Test]
        public void Game_with_all_frame_as_spare_test()
        {
            var game = new Game();
            for (int i = 0; i < 9; i++)
            {
                game.CreateFrame(5,5);
            }
            //Last frame with extra roll
            game.CreateFrame(5, 5, 5);
            Assert.AreEqual(150, game.GetScore());
        }


        [Test]
        public void Game_with_perfect_score_test()
        {
            var game = new Game();
            for (int i = 0; i < 9; i++)
            {
                game.CreateFrame(10);
            }
            game.CreateFrame(10, 10, 10);
            
            Assert.AreEqual(300, game.GetScore());
        }

        [Test]
        public void Test_random_game_with_mix_of_spare_and_strike()
        {
            var game = new Game();

            game.CreateFrame(10);
            game.CreateFrame(9,1);
            game.CreateFrame(5,5);
            game.CreateFrame(7,2);
            game.CreateFrame(10);
            game.CreateFrame(10);
            game.CreateFrame(10);
            game.CreateFrame(9);
            game.CreateFrame(8,2);
            game.CreateFrame(9, 1, 10);

            Assert.AreEqual(187, game.GetScore());
        }
    }
}
