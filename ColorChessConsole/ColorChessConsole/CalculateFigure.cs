namespace ColorChessConsole;

public class CalculateFigure
{

    public List<Cell> CalculateAllWayPawn(Map map, Figure figure)
    {
        List<Cell> avaibleCell = new List<Cell>();

        Position posFigure = figure.pos;

        for (int i = posFigure.X - 1; i <= posFigure.X + 1; i++)
        {
            for (int j = posFigure.Y - 1; j <= posFigure.Y + 1; j++)
            {
                Position posCell = new Position(i, j);

                if ((OutOfRange(posCell, map) ||
                    SelfPoint(posCell, posFigure)) == true) { continue; } 

                Cell cell = map.GetCell(posCell);

                // Чтобы не съесть свою фигуру
                if (cell.numberPlayer == figure.GetNumberPlayer() &&
                    cell.figureType != FigureType.Empty) { continue; }

                if (Avaible(posCell, figure, map) == false) { continue; }

                avaibleCell.Add(cell);
            }
        }

        return avaibleCell;
    }

    public List<Cell> CalculateAllWayBishop(Map map, Figure figure)
    {
        List<Cell> avaibleCell = new List<Cell>();

        Position posFigure = figure.pos;


        for (int i = -3; i <= 3; i += 2)
        {
            if (Math.Abs(i) == 3) 
            {
                for (int j = 0; j < map.cells.GetLength(0); j++)
                {
                    Position posCell = new Position(posFigure.X + j * (i % 2), posFigure.Y + j * (i % 2));

                    if (OutOfRange(posCell, map) == true) { break; }
                    if (SelfPoint(posCell, posFigure) == true)  { continue; }

                    Cell cell = map.GetCell(posCell);

                    if (BusyCell(cell) == true) { break; }

                    if (Avaible(posCell, figure, map) == false) { break; }

                    avaibleCell.Add(cell);
                }
            }
            else
            {
                for (int j = 0; j < map.cells.GetLength(1); j++)
                {
                    Position posCell = new Position(posFigure.X + j * (i % 2), posFigure.Y - j * (i % 2));

                    if (OutOfRange(posCell, map) == true) { break; }
                    if (SelfPoint(posCell, posFigure) == true) { continue; }

                    Cell cell = map.GetCell(posCell);

                    if (BusyCell(cell) == true) { break; }

                    if (Avaible(posCell, figure, map) == false) { break; }

                    avaibleCell.Add(cell);
                }
            }

        }

        return avaibleCell;
    }


    public List<Cell> CalculateWayPawn(Map map, Position posStart, Position posEnd)
    {
        List<Cell> way = new List<Cell>();

        way.Add(map.GetCell(posStart));
        way.Add(map.GetCell(posEnd));

        return way;
    }







    public bool StandartCheck(int i, int j, Position pos, Map map, Figure figure)
    {
        if (i < 0 ||
            j < 0 ||
            i > map.cells.GetLength(0) - 1 ||
            j > map.cells.GetLength(1) - 1 ||
            (i == pos.X && j == pos.Y) ||
            map.cells[i, j].Avaible(figure.require, figure.GetNumberPlayer()) == false)
        { return false; }

        return true;
    }

    public bool OutOfRange(Position posCell, Map map)
    {
        if (posCell.X < 0 ||
            posCell.Y < 0 ||
            posCell.X > map.cells.GetLength(0) - 1 ||
            posCell.Y > map.cells.GetLength(1) - 1)
        { return true; }

        return false;
    }

    public bool SelfPoint(Position posCell, Position posFigure)
    {
        if (posCell == posFigure) { return true; }

        return false;
    }

    public bool Avaible(Position posCell, Figure figure, Map map)
    {
        return map.cells[posCell.X, posCell.Y].Avaible(figure.require, figure.GetNumberPlayer());
    }

    public bool BusyCell(Cell cell)
    {
        if (cell.figureType != FigureType.Empty) { return true; }
        return false;
    }
}
