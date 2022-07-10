using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChessConsole;

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
        return player;
    }
}

