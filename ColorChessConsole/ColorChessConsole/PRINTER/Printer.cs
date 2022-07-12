namespace ColorChessConsole.PRINTER;

public class Printer
{
    public static void PrintMap(Map map)
    {
        string mapString = "   \t";

        for (int i = 0; i < map.Width; i++)
        {
            mapString += i.ToString() + "  \t";
        }

        mapString += "\n";

        for (int i = 0; i < map.Width; i++)
        {
            mapString += i.ToString() + "  \t";

            for (int j = 0; j < map.Length; j++)
            {
                mapString += GetStringCell(map.cells[i, j]) + "\t";
            }

            mapString += "\n\n";
        }

        Console.WriteLine(mapString);
    }

    public static string GetStringCell(Cell cell)
    {
        string str = "";

        str += cell.numberPlayer;

        switch (cell.type)
        {
            case CellType.Empty:
                str += "E";
                break;
            case CellType.Paint:
                str += "P";
                break;
            case CellType.Dark:
                str += "D";
                break;
            case CellType.Block:
                str += "B";
                break;
            default:
                str += "!";
                break;
        }

        switch (cell.FigureType)
        {
            case FigureType.Empty:
                str += "E";
                break;
            case FigureType.Pawn:
                str += "P";
                break;
            case FigureType.King:
                str += "K";
                break;
            case FigureType.Bishop:
                str += "B";
                break;
            case FigureType.Castle:
                str += "C";
                break;
            case FigureType.Horse:
                str += "H";
                break;
            case FigureType.Queen:
                str += "Q";
                break;
            default:
                str += "!";
                break;
        }
        





        return str;
    }
}
