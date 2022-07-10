using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChessConsole;

//Описывает всех игроков для создания
struct PlayersDiscription
{
    public List<CornerType> PlayerCorners;
    public List<PlayerType> PlayerTypes;
    public List<ColorType> PlayerColors;
    public List<int> PlayerNumbers;
}


//Описывает игровую доску для создания
struct CellDiscription
{
    public int width;
    public int lenght;
    public CellType[,] CellTypes;
}

//Описывает набор фигур ОДНОГО игрока
struct FigureSetDiscription
{
    public List<Position> positions;
    public List<FigureType> figureTypes;
}

struct StandartFigureSet
{

}