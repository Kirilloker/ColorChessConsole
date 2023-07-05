using ColorChessConsole.Model.GameState;

interface IAI
{
    public Step getStep(Map CurrentGameState);
}
