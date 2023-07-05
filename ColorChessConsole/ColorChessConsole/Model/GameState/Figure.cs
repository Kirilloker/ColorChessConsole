using System.Collections.Generic;

namespace ColorChessConsole.Model.GameState
{
    public class Figure
    {
        public Position pos;
        public FigureType type;
        public Player player;
        public Dictionary<CellType, bool>[] require;


        public Figure() { }

        public Figure(Figure anotherFigure, Player newPlayer)
        {
            pos = new Position(anotherFigure.pos);
            type = anotherFigure.type;
            player = newPlayer;
            require = anotherFigure.require;
        }

        public int Number
        {
            get { return player.number; }
        }

        public bool Equals(Figure anotherFigure)
        {
            return pos == anotherFigure.pos && type == anotherFigure.type && Number == anotherFigure.Number;
        }

        public override int GetHashCode()
        {
            return
                pos.GetHashCode() *
                type.GetHashCode();
        }


        public string GetStringForHash()
        {
            return pos.GetStringForHash() + Number.ToString();
        }
    };
}