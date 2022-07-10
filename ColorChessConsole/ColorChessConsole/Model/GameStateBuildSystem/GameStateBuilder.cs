namespace ColorChessConsole;

class GameStateBuilder
{
    private Map gameState;

    private FigureBuilderDirector figureBuilder;
    private PlayerBuilder playerBuilder;
    private CellBuilder cellBuilder;


    private PlayersDiscription playersDiscription;
    private CellDiscription board;
    private List<FigureSetDiscription>? figureSets;

    public GameStateBuilder()
    { 
        gameState = new Map();

        figureBuilder = new FigureBuilderDirector();
        playerBuilder = new PlayerBuilder();
        cellBuilder = new CellBuilder();
    }

    public Map CreateGameState()
    {
        //Создаем игроков
        for(int i = 0; i < playersDiscription.PlayerNumbers.Count; i++)
        {
            gameState.players.Add(playerBuilder.MakePlayer(
                playersDiscription.PlayerCorners[i],
                playersDiscription.PlayerColors[i],
                playersDiscription.PlayerTypes[i],
                playersDiscription.PlayerNumbers[i]));
        }

        //Создаем фигуры и передаем ссылку на них игрокам
        for(int i = 0; i < figureSets.Count; i++)
        {
            for (int j = 0; j < figureSets[i].positions.Count; j++)
            {
                gameState.players[i].figures.Add(
                    figureBuilder.MakeFigure(
                        figureSets[i].positions[j],
                        gameState.players[i],
                        figureSets[i].figureTypes[j]));
            }
        }

        //Создаем игровое поле
        for (int i = 0; i < board.lenght; i++)
        {
            for (int j = 0; j < board.width; j++)
            {
                gameState.cells[i, j] = cellBuilder.MakeCell(
                    new Position(i, j),
                    board.CellTypes[i, j]);
            }
        }

        //Тут мы обращаемся к GameStateCalculator
        //И обновляем состояния клеток (ставим фигуры на игровое поле)
        GameStateCalcSystem.UpdateGameStateForBuilder(gameState);

        return gameState;
    }

    public void SetStandartBoard()
    {
   
    }

    
}
