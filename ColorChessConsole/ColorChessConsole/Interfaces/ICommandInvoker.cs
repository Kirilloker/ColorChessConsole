namespace ColorChessConsole;
interface ICommandInvoker
{
    void SetCommand(ICommand command);
    void SendCommand();
}