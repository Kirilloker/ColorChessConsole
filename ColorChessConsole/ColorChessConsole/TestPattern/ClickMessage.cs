namespace ColorChessConsole.TestPattern;

public class ClickMessage : IMessage
{
    object? position;

    public ClickMessage(object o)
    {
        position = o;
    }
    public void InputDate(object o)
    {
        position = o;
    }

    public object OutputDate()
    {
        return position;
    }
}
