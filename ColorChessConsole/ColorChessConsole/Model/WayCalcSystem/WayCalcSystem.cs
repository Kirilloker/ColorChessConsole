﻿namespace ColorChessConsole;

class WayCalcSystem
{
    private static WayCalcStrategy? algorithm;

    private static void SetAlgorithm(WayCalcStrategy _algorithm)
    {
        algorithm = _algorithm;
    }
    private static void ChooseAlgorithm(FigureType targetAlgorithm)
    {
        switch (targetAlgorithm)
        {
            case FigureType.Pawn:
                SetAlgorithm(new PawnAlgorithm());
                break;
            case FigureType.King:
                SetAlgorithm(new KingAlgorithm());
                break;
            case FigureType.Bishop:
                SetAlgorithm(new BishopAlgorithm());
                break;
            case FigureType.Castle:
                SetAlgorithm(new CastleAlgorithm());
                break;
            case FigureType.Horse:
                SetAlgorithm(new HorseAlgorithm());
                break;
            case FigureType.Queen:
                SetAlgorithm(new QueenAlgorithm());
                break;
            default:
                DebugConsole.Print("Error: Cant calc way for Empty FigureType");
                break;
        }
    }
    public static List<Cell> CalcAllSteps(Map map, Figure figure)
    {
        ChooseAlgorithm(figure.type);
        return algorithm.AllSteps(map, figure);
    }

    public static List<Cell> CalcWay(Map map, Position startPos, Position endPos, Figure figure)
    {
        ChooseAlgorithm(figure.type);
        return algorithm.Way(map, startPos, endPos, figure);
    }
}

