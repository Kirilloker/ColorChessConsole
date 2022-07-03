using System.Collections.Generic;


namespace ColorChessConsole;

public class Player
{
    public int number;
    private CornerType corner;
    //private Color color;
    private PlayerType type;

    //List<Figure> figures;

    private Player() { }

    public Player(Player anotherPlayer)
    {
        number = anotherPlayer.number;
        corner = anotherPlayer.corner;
        //color = anotherPlayer.color;
        type = anotherPlayer.type;

        //this.figures = new List<Figure>();
        
        //for (int i = 0; i < anotherPlayer.Count; i++)
        //{
        //    this.figures.Add(new Figure(anotherPlayer.figures[i]));
        //}

    }
}
