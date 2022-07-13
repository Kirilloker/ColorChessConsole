namespace ColorChessConsole;

class QueenAlgorithm : WayCalcStrategy
{
    public List<Cell> AllSteps(Map map, Figure figure)
    {
        List<Cell> avaibleCell = new List<Cell>();

        Dictionary<Cell, int> dict = new Dictionary<Cell, int>();

        Position posFigure = figure.pos;

        for (int i = -3; i <= 3; i += 2)
        {
            if (Math.Abs(i) == 3)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    Position posCell = new Position(posFigure.X + j * (i % 2), posFigure.Y + j * (i % 2));

                    if (Check.OutOfRange(posCell, map) == true) { break; }

                    if (Check.SelfPoint(posCell, posFigure) == true) { continue; }

                    Cell cell = map.GetCell(posCell);

                    if (Check.BusyCell(cell) == true
                        ||
                        Check.Avaible(posCell, figure, map) == false) { break; }

                    //avaibleCell.Add(cell);

                    // Добавляем клетку и расстояние от фигуры до клетки 
                    dict.Add(cell, Math.Abs(figure.pos.X - cell.pos.X) + Math.Abs(figure.pos.Y - cell.pos.Y));
                }

                for (int j = 0; j < map.Width; j++)
                {
                    Position posCell = new Position(posFigure.X + j * (i % 2), posFigure.Y);

                    if (Check.OutOfRange(posCell, map) == true) { break; }

                    if (Check.SelfPoint(posCell, posFigure) == true) { continue; }

                    Cell cell = map.GetCell(posCell);

                    if (Check.BusyCell(cell) == true
                        ||
                        Check.Avaible(posCell, figure, map) == false) { break; }

                    //avaibleCell.Add(cell);

                    // Добавляем клетку и расстояние от фигуры до клетки 
                    dict.Add(cell, Math.Abs(figure.pos.X - cell.pos.X) + Math.Abs(figure.pos.Y - cell.pos.Y));
                }
            }
            else
            {
                for (int j = 0; j < map.Length; j++)
                {
                    Position posCell = new Position(posFigure.X + j * (i % 2), posFigure.Y - j * (i % 2));

                    if (Check.OutOfRange(posCell, map) == true) { break; }

                    if (Check.SelfPoint(posCell, posFigure) == true) { continue; }

                    Cell cell = map.GetCell(posCell);

                    if (Check.BusyCell(cell) == true
                        ||
                        Check.Avaible(posCell, figure, map) == false) { break; }

                    //avaibleCell.Add(cell);

                    // Добавляем клетку и расстояние от фигуры до клетки 
                    dict.Add(cell, Math.Abs(figure.pos.X - cell.pos.X) + Math.Abs(figure.pos.Y - cell.pos.Y));
                }

                for (int j = 0; j < map.Length; j++)
                {
                    Position posCell = new Position(posFigure.X, posFigure.Y + j * (i % 2));

                    if (Check.OutOfRange(posCell, map) == true) { break; }

                    if (Check.SelfPoint(posCell, posFigure) == true) { continue; }

                    Cell cell = map.GetCell(posCell);

                    if (Check.BusyCell(cell) == true
                        ||
                        Check.Avaible(posCell, figure, map) == false) { break; }

                    //avaibleCell.Add(cell);

                    // Добавляем клетку и расстояние от фигуры до клетки 
                    dict.Add(cell, Math.Abs(figure.pos.X - cell.pos.X) + Math.Abs(figure.pos.Y - cell.pos.Y));
                }
            }

        }

        // Сортируем словарь и добовляем всё в массив
        dict = dict.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

        foreach (Cell cell in dict.Keys)
        {
            avaibleCell.Add(cell);
        }

        avaibleCell.Reverse();

        return avaibleCell;
    }

    public List<Cell> Way(Map map, Position startPos, Position endPos, Figure figure)
    {
        List<Cell> way = new List<Cell>();

        for (int i = -3; i <= 3; i += 2)
        {
            way.Clear();

            if (Math.Abs(i) == 3)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    Position posCell = new Position(startPos.X + j * (i % 2), startPos.Y);

                    if (Check.OutOfRange(posCell, map) == true) { break; }

                    way.Add(map.GetCell(posCell));

                    if (posCell == endPos) { return way; }
                }

                way.Clear();

                for (int j = 0; j < map.Width; j++)
                {
                    Position posCell = new Position(startPos.X + j * (i % 2), startPos.Y + j * (i % 2));

                    if (Check.OutOfRange(posCell, map) == true) { break; }

                    way.Add(map.GetCell(posCell));

                    if (posCell == endPos) { return way; }
                }
            }
            else
            {
                for (int j = 0; j < map.Length; j++)
                {
                    Position posCell = new Position(startPos.X, startPos.Y + j * (i % 2));

                    if (Check.OutOfRange(posCell, map) == true) { break; }

                    way.Add(map.GetCell(posCell));

                    if (posCell == endPos) { return way; }
                }

                way.Clear();

                for (int j = 0; j < map.Length; j++)
                {
                    Position posCell = new Position(startPos.X + j * (i % 2), startPos.Y - j * (i % 2));

                    if (Check.OutOfRange(posCell, map) == true) { break; }

                    way.Add(map.GetCell(posCell));

                    if (posCell == endPos) { return way; }
                }
            }
        }

        return new List<Cell>();
    }
}

