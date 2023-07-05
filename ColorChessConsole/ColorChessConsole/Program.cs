using ColorChessConsole.Model;
using ColorChessConsole.Model.BuildSystem;
using ColorChessConsole.Model.GameState;


static void Main()
{
    GameStateBuilder gameStateBuilder = new GameStateBuilder();
    gameStateBuilder.SetDefaultAIGameState();
    Map map = gameStateBuilder.CreateGameState();


    GameController gameController = new GameController();

    gameController.SelectGameMode(GameModeType.AI);
    gameController.StartGame();
   
}

Main();



