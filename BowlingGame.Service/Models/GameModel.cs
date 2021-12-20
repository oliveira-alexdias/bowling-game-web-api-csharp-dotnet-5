namespace BowlingGame.Service.Models
{
    public class GameModel
    {
        public GameModel(string id, string playerName)
        {
            Id = id;
            PlayerName = playerName;
        }

        public GameModel(string id, string playerName, int score)
        {
            Id = id;
            PlayerName = playerName;
            Score = score;
        }

        public string Id { get; set; }
        public string PlayerName { get; set; }
        public int Score { get; set; }
    }
}
