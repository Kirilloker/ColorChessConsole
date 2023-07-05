using System.Collections.Generic;

namespace ColorChessConsole.Model.GameState
{
    public class Position
    {
        public int X;
        public int Y;

        public Position()
        {
            X = -10;
            Y = -10;
        }

        public Position(int _X, int _Y)
        {
            X = _X;
            Y = _Y;
        }

        public Position(float _X, float _Y)
        {
            X = (int)_X;
            Y = (int)_Y;
        }

        public Position(Position anotherPosition)
        {
            X = anotherPosition.X;
            Y = anotherPosition.Y;
        }


        public static Position ReadFromConsole()
        {
            Console.Write("Введите координаты позиции (X Y): ");
            string input = Console.ReadLine();
            string[] coordinates = input.Split(' ');

            if (coordinates.Length != 2 || !int.TryParse(coordinates[0], out int x) || !int.TryParse(coordinates[1], out int y))
                throw new FormatException("Некорректный ввод координат позиции.");

            return new Position { X = x, Y = y };
        }

        public static bool operator !=(Position pos1, Position pos2)
        {
            return !(pos1 == pos2);
        }

        public static bool operator ==(Position pos1, Position pos2)
        {
            return pos1.X == pos2.X && pos1.Y == pos2.Y;
        }

        public override string ToString()
        {
            return "(X:" + X + ";   Y:" + Y + ")";
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() * Y.GetHashCode();
        }

        public int _X
        {
            get { return X; }
            set { X = value; }
        }

        public int _Y
        {
            get { return Y; }
            set { Y = value; }
        }

        public string GetStringForHash()
        {
            return X.ToString() + Y.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   X == position.X &&
                   Y == position.Y &&
                   _X == position._X &&
                   _Y == position._Y;
        }
    }
}