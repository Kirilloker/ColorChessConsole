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

