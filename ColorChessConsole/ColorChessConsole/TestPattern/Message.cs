namespace ColorChessConsole.TestPattern;

public class Message
{
    object o;
    public Type type = typeof(Position);

    public Message(object _o)
    {
        o = _o;
    }

    public object OutputDate()
    {
        return o;
    }
}

