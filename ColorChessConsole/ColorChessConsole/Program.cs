using ColorChessConsole;
using ColorChessConsole.PRINTER;

static void Main()
{
    Console.WriteLine("Hello World");

    Cell[,] cells = new Cell[10, 10];

    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            cells[i, j] = new Cell(new Position(i,j));
        }
    }
    Dictionary<CellType, bool>[] require = new Dictionary<CellType, bool>[]
{
            new Dictionary<CellType, bool>() // Self
            {
                [CellType.Paint] = true, // На свои закрашенные
                [CellType.Dark] = true,  // На свои захваченные
            },
            new Dictionary<CellType, bool>() // Another
            {
                [CellType.Empty] = true, // На пустые
                [CellType.Paint] = true, // На чужие закрашенные
                [CellType.Dark] = false, // На чужие захваченные
            }
};


    List<Player> players = new List<Player>();

    Map map = new Map(cells, players);

    Player player = new Player();
    player.number = 1;

    Figure figure = new Figure();
    figure.player = player;

    Position posFigure = new Position(5, 5);
    figure.type = FigureType.Bishop;
    figure.pos = posFigure;
    figure.require = require;

    player.figures = new List<Figure>();
    player.figures.Add(figure);

    map.players.Add(player);



    map.GetCell(posFigure).figure = figure;
    map.GetCell(posFigure).type = CellType.Paint;
    map.GetCell(posFigure).numberPlayer = figure.GetNumberPlayer();



    int xStart;
    int yStart;
    int xEnd;
    int yEnd;

    while (true)
    {
        Printer.PrintMap(map);

        Console.Write("x Start: ");
        xStart = Convert.ToInt16(Console.ReadLine());

        Console.Write("y Start: ");
        yStart = Convert.ToInt16(Console.ReadLine());

        Position posStart = new Position(xStart, yStart);
        

        Console.WriteLine("Start Position: " + posStart.ToString());

        if (map.GetCell(posStart).FigureType == FigureType.Empty) { continue; }

        List<Cell> avaibleCell =  WayCalcSystem.CalcAllSteps(map, map.GetCell(posStart).figure);

        Console.WriteLine("Avaible cell:");

        for (int i = 0; i < avaibleCell.Count; i++)
        {
            Console.WriteLine(avaibleCell[i].pos.ToString());
        }

        Console.Write("xEnd: ");
        xEnd = Convert.ToInt16(Console.ReadLine());

        Console.Write("yEnd: ");
        yEnd = Convert.ToInt16(Console.ReadLine());

        Position posEnd = new Position(xEnd, yEnd);

        Console.WriteLine("End Position: " + posEnd.ToString());

        if (avaibleCell.Contains(map.GetCell(posEnd)) == true)
        {
            Console.WriteLine("Туда можно сходить");
        }
        else
        {
            Console.WriteLine("Туда нельзя сходить");
            continue;
        }


        List<Cell> Way = WayCalcSystem.CalcWay(map, posStart, posEnd, map.GetCell(posStart).figure);

        Console.WriteLine("Way cell:");

        for (int i = 0; i < Way.Count; i++)
        {
            Console.WriteLine(Way[i].pos.ToString());
        }

        for (int i = 0; i < Way.Count; i++)
        {
            Way[i].numberPlayer = figure.GetNumberPlayer();
            Way[i].type = CellType.Paint;
        }

        Way[0].figure = null;
        Way[Way.Count - 1].figure = figure;
        figure.pos = posEnd;

    }
}

Main();



