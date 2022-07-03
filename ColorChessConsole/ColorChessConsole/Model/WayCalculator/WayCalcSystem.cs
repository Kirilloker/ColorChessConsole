namespace ColorChessConsole;

class WayCalcSystem
{
    private static WayCalcStrategy? algorithm;

    private static void SetAlgorithm(WayCalcStrategy _algorithm)
    {
        algorithm = _algorithm;
    }
    private static void ChooseAlgorithm(FigureType _targetAlgorithm)
    {
        switch (_targetAlgorithm)
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
    public static List<Cell> CalcAllSteps(Map _map, Figure _figure)
    {
        FigureType targetAlgorithm = _figure.type;
        ChooseAlgorithm(targetAlgorithm);
        return algorithm.Execute(_map, _figure);
    }

    public static List<Cell> CalcWay(Map _map, Position _startPos, Position _endPos, Figure _figure)
    {
        FigureType targetAlgorithm = _figure.type;
        ChooseAlgorithm(targetAlgorithm);
        return algorithm.Execute(_map, _startPos, _endPos);
    }
}

