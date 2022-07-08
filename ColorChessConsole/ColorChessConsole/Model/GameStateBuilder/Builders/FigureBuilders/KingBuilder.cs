using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChessConsole;
class KingBuilder : FigureBuilder
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
                [CellType.Paint] = false, // На чужие закрашенные
                [CellType.Dark] = false, // На чужие захваченные
            }
        };
    }

    public override void SetFigType()
    {
        figure.type = FigureType.King;
    }
}
