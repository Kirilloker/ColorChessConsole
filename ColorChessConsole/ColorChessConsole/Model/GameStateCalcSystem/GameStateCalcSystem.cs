namespace ColorChessConsole;
class GameStateCalcSystem
{
    public static Map UpdateGameState(Map gameState)
    {
        CheckCapture(gameState);
        gameState.scorePlayer = CalculateScore(gameState);

        return gameState;
    }

    public static Map ApplyStep(Map _gameState, Step step)
    {
        Map gameState = new Map(_gameState);

        return gameState;
    }

    public static Map UpdateGameStateForBuilder(Map gameState)
    {
        foreach (Player player in gameState.players)
        {
            foreach (Figure figure in player.figures)
            {
                Cell cell = gameState.GetCell(figure.pos);

                cell.figure = figure;
                cell.numberPlayer = figure.Number;

                cell.type = CellType.Paint;
            }
        }

        return gameState;
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
                if (Check.OutOfRange(cell.pos, map) == true ||
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
    private static Dictionary<int, Dictionary<CellType, int>> GetEmptyScoreDictionary(Map map)
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
}
