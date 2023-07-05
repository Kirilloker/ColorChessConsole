using ColorChessConsole.Model.BuildSystem;
using ColorChessConsole.Model.GameState;
using ColorChessConsole.Model.GameStateCalcSystem;
using ColorChessConsole.Model.WayCalcSystem;
using ColorChessConsole.Model;
using ColorChessConsole.PRINTER;

public class GameController
{
    private List<Map> gameStates = new List<Map>();

    private GameStateBuilder gameStateBuilder = new GameStateBuilder();

    private bool IsFirstGame = true;
    private float cameraSpeed;

    // Список игроков с AI
    private IAI[] ai;

    public void StartGame()
    {
        StartGame(gameStateBuilder.CreateGameState());
    }
    public void StartGame(Map map)
    {
        // Начало игры 
        // Создаем Доску Клетки и Игроков
        gameStates.Add(map);

        InitAI();

        StartNewStep();
    }

    void InitAI() 
    {
        ai = new IAI[CurrentGameState.PlayersCount];

        for (int i = 0; i < CurrentGameState.PlayersCount; i++)
        {
            if (CurrentGameState.GetPlayerType(i) == PlayerType.AI) 
            {
                ai[i] = new MinMaxAI();
            }
            else if (CurrentGameState.GetPlayerType(i) == PlayerType.AI2)
            {
                ai[i] = new MonteCarloAI();
            }
        }
    }


    public void ApplyStepView(Step step)
    {
        // Применяем ход - отображаем всё в Unity
        // Получаем массив пути - запускаем анимацию фигуры по этому пути и перекрашиваем клеткти
        // Также меняем всё в Model 
        // И в конце запускаем новый шаг

        Figure figure = step.Figure;
        Cell cell = step.Cell;

        List<Cell> way = WayCalcSystem.CalcWay(CurrentGameState, figure.pos, cell.pos, figure);

        Map map = GameStateCalcSystem.ApplyStep(CurrentGameState, figure, cell);

        gameStates.Add(map);

        StartNewStep();
    }


    public void SelectGameMode(GameModeType gameMode)
    {
        switch (gameMode)
        {
            case GameModeType.HumanTwo:
                gameStateBuilder.SetDefaultHotSeatGameState();
                break;
            case GameModeType.HumanFour:
                //
                break;
            case GameModeType.AI:
                gameStateBuilder.SetDefaultAIGameState();
                break;
            case GameModeType.Network:
                gameStateBuilder.SetDefaultOnlineGameState();
                break;
            default:
                break;
        }
    }

    public void StartNewStep()
    {
        Printer.PrintMap(CurrentGameState);


        if (CurrentGameState.EndGame == true)
        {
            EndGame();
            return;
        }


        PlayerType playerType = CurrentGameState.GetPlayerType(CurrentGameState.NumberPlayerStep);
        
        switch (playerType)
        {
            case PlayerType.Human:
                Console.WriteLine("Human");
                HumanStep();
                break;
            case PlayerType.AI:
                AIStep(playerType);
                break;             
            case PlayerType.AI2:
                AIStep(playerType);
                break;             
            case PlayerType.Online:
                //
                break;
        }
    }

    public void HumanStep() 
    {
        while (true) 
        {
            Position posStart = Position.ReadFromConsole();
            if (CurrentGameState.GetCell(posStart).FigureType == FigureType.Empty) { continue; }
            List<Cell> avaibleCell = WayCalcSystem.CalcAllSteps(CurrentGameState, CurrentGameState.GetCell(posStart).figure);
            foreach (var cell in avaibleCell) Console.WriteLine("\t" + cell.pos.ToString());
            Position posEnd = Position.ReadFromConsole();
            if (avaibleCell.Contains(CurrentGameState.GetCell(posEnd)) == false) { Console.WriteLine("Error pos");  continue; }
            ApplyStepView(new Step(CurrentGameState.GetCell(posStart).figure, CurrentGameState.GetCell(posEnd)));
            return;
        }
    }


    public void EndGame()
    {

        IsFirstGame = false;
        gameStateBuilder = new GameStateBuilder();
        gameStates = new List<Map>();
    }

    private void LoadMap(Map map)
    {
        gameStates.Add(map);
    }

    private void AIStep(PlayerType AIType)
    {
        Step step = new();
        
        step = ai[CurrentGameState.NumberPlayerStep].getStep(CurrentGameState);

        if (gameStates.Count == 0) return;

        ApplyStepView(step);
    }


    public bool GetBoolFigureInCell(Position position)
    {
        return CurrentGameState.GetCell(position).figure != null;
    }
    public Map CurrentGameState { get { return gameStates[gameStates.Count - 1]; } }
    public Map PreviousvGameState { get { return gameStates[gameStates.Count - 2]; } }

}
