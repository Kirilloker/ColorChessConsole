namespace ColorChessConsole;

static public class Test
{
    public static List<int>  TestScore(Map map)
    {
        int OneScorePaint = 1;
        int OneScoreDark = 1;

        // Словарь(Номер игрока, словарь(Тип клетки, количество таких клеток))
        Dictionary<int, Dictionary<CellType, int>> score = TestGetEmptyScoreDictionary(map);

        for (int i = 0; i < map.cells.GetLength(0); i++)
        {
            for (int j = 0; j < map.cells.GetLength(1); j++)
            {
                Cell cell = map.GetCell(i, j);

                score[cell.numberPlayer][cell.type] += 1;
            }
        }

        if (score[-1][CellType.Empty] == 0) { DebugConsole.Print("Белые клетки закончились"); }

        List<int> scorePlayer = new List<int>();

        for (int i = 0; i < score.Count; i++)
        {
            scorePlayer.Add(
                score[i][CellType.Paint] * OneScorePaint + 
                score[i][CellType.Dark] * OneScoreDark);
        }

        return scorePlayer;
    }

    public static Dictionary<int, Dictionary<CellType, int>> TestGetEmptyScoreDictionary(Map map)
    {
        Dictionary<int, Dictionary<CellType, int>> dict = new Dictionary<int, Dictionary<CellType, int>>();

        for (int i = -1; i < map.players.Count; i++)
        {
            dict[i] = new Dictionary<CellType, int>();

            foreach (CellType cellType in Enum.GetValues(typeof(CellType)))
            {
                dict[i].Add(cellType, 0);
            }
        }

        return dict;
    }

    public static void TestStep(Map map, Figure figure, Position posEnd)
    {
        Cell cell = map.GetCell(posEnd);

        if (WayCalcSystem.CalcAllSteps(map, figure).Contains(cell) == false)
            return;

        List<Cell> way = WayCalcSystem.CalcWay(map, figure.pos, posEnd, figure);

        for (int i = 0; i < way.Count; i++)
        {
            way[i].numberPlayer = figure.Number;
            if (way[i].type != CellType.Dark) { way[i].type = CellType.Paint; }
        }

        map.GetCell(figure.pos).figure = null;
        figure.pos = posEnd;
        cell.figure = figure;
    }

    public static void TestDarkCapture(Map map)
    {
        for (int i = 0; i < map.cells.GetLength(0); i++)
        {
            for (int j = 0; j < map.cells.GetLength(1); j++)
            {
                if (map.GetCell(i,j).type != CellType.Empty &
                    map.GetCell(i,j).numberPlayer != -1)
                {
                    TestCheckCapture(map, map.GetCell(i, j));
                }
            }
        }
    }

    public static void TestCheckCapture(Map map, Cell cell) 
    {
        bool newDark = false;

        for (int i = cell.pos.X - 1; i <= cell.pos.X + 1 ; i++)
        {
            for (int j = cell.pos.Y - 1; j <= cell.pos.Y + 1; j++)
            {
                if (i < 0 || j < 0 || 
                    i >= map.cells.GetLength(0) ||
                    j >= map.cells.GetLength(1))
                { return; }

                if (map.GetCell(i, j).numberPlayer != cell.numberPlayer)
                { return; }
            }
        }

        // Если код дошел до этого момента, значит главная клетка это центр 3х3 клеток с одинаковым номером игрока

        for (int i = cell.pos.X - 1; i <= cell.pos.X + 1; i++)
        {
            for (int j = cell.pos.Y - 1; j <= cell.pos.Y + 1; j++)
            {
                if (map.GetCell(i, j).type != CellType.Dark)
                { newDark = true; }

                map.GetCell(i, j).type = CellType.Dark;
            }
        }

        //if (newDark == true) { SoundStep.Play() }
    }

    // Написать функцию, которая обработает доску 
    // То есть - изменит состояние клеток и всякое такое
}

public class TestAI
{

}