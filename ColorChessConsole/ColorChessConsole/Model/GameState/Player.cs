namespace ColorChessConsole;

public class Player
{
    public int number;
    public CornerType corner;
    public ColorType color;
    public PlayerType type;

    public List<Figure> figures;


    public Player() { }

    public Player(Player anotherPlayer)
    {
        number = anotherPlayer.number;
        corner = anotherPlayer.corner;
        color = anotherPlayer.color;
        type = anotherPlayer.type;

        this.figures = new List<Figure>();

        for (int i = 0; i < anotherPlayer.figures.Count; i++)
        {
            this.figures.Add(new Figure(anotherPlayer.figures[i]));
        }
    }

    public override string ToString()
    {
        string Logs = "";

        Logs += "Number: " + number.ToString() + "\n";

        Logs += "Type: " + Types.ToString(type) + "\n";

        Logs += "Corner: " + Types.ToString(corner) + "\n";

        Logs += "Color: " + Types.ToString(color) + "\n";

        for (int i = 0; i < figures.Count; i++)
        {
            Logs += figures[i].ToString() + "\n";
        }

        return Logs;
    }
}
