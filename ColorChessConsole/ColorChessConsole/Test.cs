namespace ColorChessConsole;

public class Test
{
    void Test1()
    {
        int numberPlayer = 1;
        int numberPlayerCell = 2;
        CellType cellType = CellType.Dark;

        Dictionary<CellType, bool>[] require = new Dictionary<CellType, bool>[]
        {
            new Dictionary<CellType, bool>() // Self
            {
                [CellType.Paint] = true, // На свои закрашенные
                [CellType.Dark] = true,  // На свои захваченные
            },
            new Dictionary<CellType, bool>() // Another
            {
                [CellType.Empty] = true, // На пустые
                [CellType.Paint] = true, // На чужие закрашенные
                [CellType.Dark] = false, // На чужие захваченные
            }
        };

    }


}
