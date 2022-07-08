namespace ColorChessConsole;

class PawnAlgorithm : WayCalcStrategy
{
    public List<Cell> AllSteps(Map map, Figure figure)
    {
        List<Cell> avaibleCell = new List<Cell>();

        Position posFigure = figure.pos;

        for (int i = posFigure.X - 1; i <= posFigure.X + 1; i++)
        {
            for (int j = posFigure.Y - 1; j <= posFigure.Y + 1; j++)
            {
                Position posCell = new Position(i, j);

                if ((Check.OutOfRange(posCell, map) ||
                    Check.SelfPoint(posCell, posFigure)) == true) { continue; }

                Cell cell = map.GetCell(posCell);

                // Чтобы не съесть свою фигуру
                if (cell.numberPlayer == figure.GetNumberPlayer() &&
                    cell.figureType != FigureType.Empty) { continue; }

                if (Check.Avaible(posCell, figure, map) == false) { continue; }

                avaibleCell.Add(cell);
            }
        }

        return avaibleCell;

    }

    public List<Cell> Way(Map map, Position startPos, Position endPos)
    {
        List<Cell> way = new List<Cell>();

        way.Add(map.GetCell(startPos));
        way.Add(map.GetCell(endPos));

        return way;
    }
}

