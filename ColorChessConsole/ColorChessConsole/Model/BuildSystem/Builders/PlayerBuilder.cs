using System.Collections.Generic;
using ColorChessConsole.Model.GameState;

namespace ColorChessConsole.Model.BuildSystem.Builders
{
    class PlayerBuilder
    {
        private Player player;

        public PlayerBuilder()
        {
            player = new Player();
        }

        public Player MakePlayer(CornerType corner, ColorType color, PlayerType type, int number)
        {
            player.number = number;
            player.corner = corner;
            player.color = color;
            player.type = type;

            return new Player(player);
        }
    }
}