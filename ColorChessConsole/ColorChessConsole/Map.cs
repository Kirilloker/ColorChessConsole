using System.Collections.Generic;

namespace ColorChessConsole;

public class Map
{
    Cell[,] cells = null;
    //List<Player> players = new List<Player>();

    private Map() { }

    public Map(Cell[,] _cells) // List<Player> _players
    {
        this.cells = _cells;
        //this.players = _players;
    }

    public Map(Map anotherMap)
    {

    }
}
