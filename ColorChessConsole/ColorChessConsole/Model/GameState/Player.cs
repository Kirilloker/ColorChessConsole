using System.Collections.Generic;

namespace ColorChessConsole.Model.GameState
{
    public class Player
    {
        public int number;
        public CornerType corner;
        public ColorType color;
        public PlayerType type;

        public List<Figure> figures = new List<Figure>();


        public Player() { }

        public Player(Player anotherPlayer)
        {
            number = anotherPlayer.number;
            corner = anotherPlayer.corner;
            color = anotherPlayer.color;
            type = anotherPlayer.type;

            figures = new List<Figure>();

            for (int i = 0; i < anotherPlayer.figures.Count; i++)
            {
                figures.Add(new Figure(anotherPlayer.figures[i], this));
            }
        }

        public string GetStringForHash()
        {
            string stringForHash = number.ToString();

            for (int i = 0; i < figures.Count; i++)
            {
                stringForHash += figures[i].GetStringForHash();
            }

            return stringForHash;
        }
    };
}