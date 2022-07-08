namespace ColorChessConsole;
public static class Check
{
    public static bool OutOfRange(Position posCell, Map map)
    {
        if (posCell.X < 0 ||
            posCell.Y < 0 ||
            posCell.X > map.cells.GetLength(0) - 1 ||
            posCell.Y > map.cells.GetLength(1) - 1)
        { return true; }

        return false;
    }

    public static bool SelfPoint(Position posCell, Position posFigure)
    {
        if (posCell == posFigure) { return true; }

        return false;
    }

    public static bool Avaible(Position posCell, Figure figure, Map map)
    {
        return map.GetCell(posCell).Avaible(figure.require, figure.GetNumberPlayer());
    }


    public static bool BusyCell(Cell cell)
    {
        if (cell.FigureType != FigureType.Empty) { return true; }
        return false;
    }
}
