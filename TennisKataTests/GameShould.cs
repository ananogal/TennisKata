using NUnit.Framework;
using FluentAssertions;
using TennisKata;

namespace TennisKataTests
{
    [TestFixture]
    public class GameShould
    {
        Game game;
        Player player1;
        Player player2;

        [SetUp]
        public void BeforeEach()
        {
           player1 = new Player("Player1");
           player2 = new Player("Player2");
           game = new Game(player1, player2);
        }

        [Test]
        public void BeStartedStartWillAScoreOfZero()
        {
            game.Score.Should().Be("0:0");
        }

        [Test]
        public void AddPointToWinningPlayer()
        {
            game.AddPointTo(player1);
            game.Score.Should().Be("15:0");
        }

        [Test]
        public void HaveAScoreOfFifteenThirtyWhenPlayer2WinsAndScoreWasFifteenFifteen()
        {
            game.AddPointTo(player1);
            game.AddPointTo(player2);

            game.AddPointTo(player2);

            game.Score.Should().Be("15:30");
        }

        [Test]
        public void HaveAScoreOfFortyThirtyWhenPlayer1WinsAndScoreWasThirtyThirty()
        {
            SetScoreForPlayer(player1, 2);
            SetScoreForPlayer(player2, 2);

            game.AddPointTo(player1);

            game.Score.Should().Be("40:30");
        }

        [Test]
        public void HaveAScoreOfDeuceWhenPlayersAreTieWithForty()
        {
            SetDeuceScore();
            game.Score.Should().Be("Deuce");
        }

        [Test]
        public void HaveAScoreOfAdvantajePlayer1WhenPlayer1WinsAfterDeuce()
        {
            SetDeuceScore();
            game.AddPointTo(player1);

            game.Score.Should().Be("Advantage Player1");
        }

        [Test]
        public void HaveAScoreOfAdvantajePlayer2WhenPlayer2WinsAfterDeuce()
        {
            SetDeuceScore();
            game.AddPointTo(player2);

            game.Score.Should().Be("Advantage Player2");
        }

        [Test]
        public void ShouldDeclarePlayer1AsAWinnerWhenScoreIsThirtyFortyAndPlayer1ScoresOnePoint()
        {
            SetScoreForPlayer(player1, 3);
            SetScoreForPlayer(player2, 2);

            game.AddPointTo(player1);

            game.Score.Should().Be("Game for Player1");
        }

        [Test]
        public void ShouldDeclarePlayer2AsAWinnerWhenScoreIsThirtyFortyAndPlayer2ScoresOnePoint()
        {
            SetScoreForPlayer(player1, 2);
            SetScoreForPlayer(player2, 3);

            game.AddPointTo(player2);

            game.Score.Should().Be("Game for Player2");
        }

        private void SetDeuceScore()
        {
            SetScoreForPlayer(player1, 3);
            SetScoreForPlayer(player2, 3);
        }

        private void SetScoreForPlayer(Player player, int times)
        {
            for (int i = 0; i < times; i++)
            {
                 game.AddPointTo(player);
            }
        }
    }
}
