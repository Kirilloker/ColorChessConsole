﻿namespace ColorChessConsole;
class BishopBuilder : FigureBuilder
{
    public override void SetFigRequire()
    {
        Dictionary<CellType, bool>[] figRequire = new Dictionary<CellType, bool>[]
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
            }
        };
    }

    public override void SetFigType()
    {
        figure.type = FigureType.Bishop;
    }
}
