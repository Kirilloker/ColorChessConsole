namespace ColorChessConsole;
class GameStateCalcSystem
{
    public static Map UpdateGameState(Map map)
    {
        CheckCapture(map);
        // Внутри этой функции заполняется поле countEmptyCell в gamestate
        map.scorePlayer = CalculateScore(map);

        return map;
    }

    public static Map ApplyStep(Map _map, Figure figure, Cell endCell)
    {
        // В игре это работать не будет, но нужно для тестов

        Map map = new Map(_map);

        // Получаем ссылку на новую фигуру, которая делает ход
        Figure newFigure = map.GetCell(figure.pos).figure;

        List<Cell> Way = WayCalcSystem.CalcWay(map, newFigure.pos, endCell.pos, newFigure);

        // В клетках, по которым проходит путь фигур меняем номер игрока и перекрашивает в Paint
        for (int i = 0; i < Way.Count; i++)
        {
            Way[i].numberPlayer = newFigure.Number;
            Way[i].type = CellType.Paint;
        }

        // На клетке где изначально стояла фигура убираем ссылку на фигуру
        Way[0].figure = null;
        // В конечной клетке присваиваем ссылку на фигуру
        Way[Way.Count - 1].figure = newFigure;
        // В фигуре которая сходила меняем её позицию
        newFigure.pos = new Position(endCell.pos);
        
        // Обновляем карту
        UpdateGameState(map);

        // Увеличиваем количество ходов
        map.countStep++;

        return map;
    }

    public static Map UpdateGameStateForBuilder(Map map)
    {
        foreach (Player player in map.players)
        {
            foreach (Figure figure in player.figures)
            {
                Cell cell = map.GetCell(figure.pos);

                cell.figure = figure;
                cell.numberPlayer = figure.Number;

                cell.type = CellType.Paint;
            }
        }

        return map;
    }


    private static void CheckCapture(Map map)
    {
        // Делает квадраты захваченными

        for (int i = 0; i < map.Width; i++)
        {
            for (int j = 0; j < map.Length; j++)
            {
                if (map.GetCell(i, j).type != CellType.Empty &
                    map.GetCell(i, j).numberPlayer != -1)
                {
                    MakeCapture(map, map.GetCell(i, j));
                }
            }
        }
    }
    private static void MakeCapture(Map map, Cell cell)
    {
        bool newDark = false;

        for (int i = cell.pos.X - 1; i <= cell.pos.X + 1; i++)
        {
            for (int j = cell.pos.Y - 1; j <= cell.pos.Y + 1; j++)
            {
                Position newPos = new Position(cell.pos.X + i, cell.pos.Y + j);

                if (Check.OutOfRange(newPos, map) == true ||
                    map.GetCell(i, j).numberPlayer != cell.numberPlayer)
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
    private static List<int> CalculateScore(Map map)
    {
        int OneScorePaint = 1;
        int OneScoreDark = 1;

        // Словарь(Номер игрока, словарь(Тип клетки, количество таких клеток))
        Dictionary<int, Dictionary<CellType, int>> score = GetEmptyScoreDictionary(map);

        for (int i = 0; i < map.Width; i++)
        {
            for (int j = 0; j < map.Length; j++)
            {
                Cell cell = map.GetCell(i, j);

                score[cell.numberPlayer][cell.type] += 1;

            }
        }

        // Заполняем поле количество пустых клеток
        if (score[-1][CellType.Empty] == 0) { DebugConsole.Print("Белые клетки закончились"); }
        map.countEmptyCell = score[-1][CellType.Empty];

        List<int> scorePlayer = new List<int>();

        for (int i = -1; i < score.Count - 1; i++)
        {
            scorePlayer.Add(
                score[i][CellType.Paint] * OneScorePaint +
                score[i][CellType.Dark] * OneScoreDark);
        }

        return scorePlayer;
    }
    private static Dictionary<int, Dictionary<CellType, int>> GetEmptyScoreDictionary(Map map)
    {
        // Если номера игроков не будут начинаться с 0 и идти по порядку то тут всё сломается
        // Надеюсь такого не будет а то мне лень исправлять
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
}
