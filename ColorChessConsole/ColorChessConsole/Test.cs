namespace ColorChessConsole;

public class Test
{
    public void TestDarkCapture(Map map)
    {
        for (int i = 0; i < map.cells.GetLength(0); i++)
        {
            for (int j = 0; j < map.cells.GetLength(1); j++)
            {
                if (map.GetCell(i,j).type != CellType.Empty)
                {
                    TestCheckCapture(map, map.GetCell(i, j));
                }
            }
        }
    }

    public void TestCheckCapture(Map map, Cell cell) 
    {
        bool newDark = false;

        for (int i = cell.pos.X - 1; i <= cell.pos.X ; i++)
        {
            for (int j = cell.pos.Y - 1; i <= cell.pos.Y; i++)
            {
                if (i < 0 || j < 0 || 
                    i >= map.cells.GetLength(0) ||
                    j >= map.cells.GetLength(1))
                { return; }

                if (map.GetCell(i, j).NumberPlayer != cell.NumberPlayer)
                { return; }
            }
        }

        // Если код дошел до этого момента, значит главная клетка это центр 3х3 клеток с одинаковым номером игрока

        for (int i = cell.pos.X - 1; i <= cell.pos.X; i++)
        {
            for (int j = cell.pos.Y - 1; i <= cell.pos.Y; i++)
            {
                if (map.GetCell(i, j).type != CellType.Dark)
                { newDark = true; }

                map.GetCell(i, j).type = CellType.Dark;
            }
        }

        //if (newDark == true) { SoundStep.Play() }
    }
}
