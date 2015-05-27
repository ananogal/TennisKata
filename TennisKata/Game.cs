using System.Collections.Generic;

namespace TennisKata
{
    public class Game
    {
        private Player player1;
        private Player player2;

        string score;

        Dictionary<int, string> ScoreValues = new Dictionary<int, string>
        {
            {0, "0"},
            {1, "15"},
            {2, "30"},
            {3, "40"}
        };

        const int ADVANTAGE_POINTS_TO_WIN = 2;

        public string Score
        {
            get { return score; }
            set { score = value; }
        }

        public Game(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.score = "0:0";
        }

        public void AddPointTo(Player player)
        {
            if (player == player1)
            {
                player1.AddPoint();
            }
            else
            {
                player2.AddPoint();
            }

            CalculateScore();
        }

        private void CalculateScore()
        {
            Player winner = GetWinner();
            if (winner != null)
            {
                this.score = "Game for " + winner.Name;
            }
            else 
            {
                CalculateNoWinnerScore();
            }
        }

        private Player GetWinner()
        {
            if (IsGameInAdvantage())
            {
                if ((player1.Points >= player2.Points + ADVANTAGE_POINTS_TO_WIN))
                {
                    return player1;
                }

                if (player2.Points >= player1.Points + ADVANTAGE_POINTS_TO_WIN)
                {
                    return player2;
                }
            }
            return null;
        }

        private void CalculateNoWinnerScore()
        {
            if (IsGameDeuce())
            {
                this.score = "Deuce";
            }
            else if (IsGameInAdvantage())
            {
                if (player1.Points > player2.Points)
                {
                    this.score = "Advantage " + player1.Name;
                }
                else
                {
                    this.score = "Advantage " + player2.Name;
                }
            }
            else
            {
                this.score = ScoreValues[player1.Points] + ":" + ScoreValues[player2.Points];
            }
        }

        private bool IsGameDeuce()
        {
            return player1.Points >= 3 && player1.Points == player2.Points;
        }

        private bool IsGameInAdvantage()
        {
            return player1.HasMoreThanThreePoints() || player2.HasMoreThanThreePoints();
        }
    }
}
