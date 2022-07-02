﻿namespace ColorChessConsole
{
    public static class Types
    {
        // На вход поступает Енуменатор - возвращает строку 
        public static string ToString(PlayerType playerType)
        {
            switch (playerType)
            {
                case PlayerType.Human:
                    return "Human";
                case PlayerType.AI:
                    return "AI";
                case PlayerType.Online:
                    return "Online";
                default:
                    DebugConsole.Print("Unknown type Player");
                    return "WARNING!";
            }
        }

        public static string ToString(CellType cellType)
        {
            switch (cellType)
            {
                case CellType.Empty:
                    return "Empty";
                case CellType.Paint:
                    return "Paint";
                case CellType.Dark:
                    return "Dark";
                default:
                    DebugConsole.Print("Unknown type Cell");
                    return "WARNING!";
            }
        }


        public static string ToString(FigureType figureType)
        {
            switch (figureType)
            {
                case FigureType.Empty:
                    return "Empty";
                case FigureType.Pawn:
                    return "Pawn";
                case FigureType.King:
                    return "King";
                case FigureType.Bishop:
                    return "Bishop";
                case FigureType.Castle:
                    return "Castle";
                case FigureType.Horse:
                    return "Horse";
                case FigureType.Queen:
                    return "Queen";
                default:
                    DebugConsole.Print("Unknown type Figure");
                    return "WARNING!";
            }
        }

        public static string ToString(Corner corner)
        {
            switch (corner)
            {
                case Corner.DownLeft:
                    return "DownLeft";
                case Corner.DownRight:
                    return "DownRight";
                case Corner.UpRight:
                    return "UpRight";
                case Corner.UpLeft:
                    return "UpLeft";
                default:
                    DebugConsole.Print("Unknown type Corner");
                    return "WARNING!";
            }
        }

        // На вход получает строку - возращает Енуменатор
        public static CellType ToType(string strCellType)
        {
            switch (strCellType)
            {
                case "void":
                    return CellType.Empty;
                case "empty":
                    return CellType.Empty;
                case "paint":
                    return CellType.Paint;
                case "dark":
                    return CellType.Dark;
                default:
                    DebugConsole.Print("Unknown type str Cell");
                    return CellType.Empty;
            }
        }


    }



    public enum CellType
    {
        Empty,
        Paint,
        Dark
    }

    public enum FigureType
    {
        Empty,
        Pawn,
        King,
        Bishop,
        Castle,
        Horse,
        Queen
    }

    public enum Corner
    {
        Empty,
        UpLeft,
        UpRight,
        DownLeft,
        DownRight,
    }

    public enum PlayerType
    {
        Human,
        AI,
        Online
    }


}
