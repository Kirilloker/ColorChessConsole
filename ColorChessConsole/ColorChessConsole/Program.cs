using ColorChessConsole;
using ColorChessConsole.PRINTER;
using System.Collections;

static void Main()
{
    GameStateBuilder gameStateBuilder = new GameStateBuilder();
    gameStateBuilder.SetDefaultAIGameState();
    Map map = gameStateBuilder.CreateGameState();

    int xStart;
    int yStart;
    int xEnd;
    int yEnd;

    //Dictionary<uint, int> TestHashTable = new Dictionary<uint, int>();
    Hashtable hashtable = new Hashtable();

    while (true)
    {
        //Console.WriteLine(TestHashTable.ContainsKey(map.GetHash()));
        //TestHashTable.Add(map.GetHash(), 1);

        Console.WriteLine(hashtable.ContainsKey(map.GetHash()));
        hashtable.Add(map.GetHash(), 1);


        
        Printer.PrintMap(map);

        Console.Write("x Start: ");
        xStart = Convert.ToInt16(Console.ReadLine());
        Console.Write("y Start: ");
        yStart = Convert.ToInt16(Console.ReadLine());

        Position posStart = new Position(xStart, yStart);

        Console.WriteLine("Start Position: " + posStart.ToString());

        if (map.GetCell(posStart).FigureType == FigureType.Empty) { continue; }

        List<Cell> avaibleCell = WayCalcSystem.CalcAllSteps(map, map.GetCell(posStart).figure);

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

        map = GameStateCalcSystem.ApplyStep(map, map.GetCell(posStart).figure, map.GetCell(posEnd));


        //TestAI.AlphaBeta(map, 0, int.MinValue, int.MaxValue);
        //map = GameStateCalcSystem.ApplyStep(map, TestAI.bestFigure1, TestAI.bestCell1);
    }
}

Main();



