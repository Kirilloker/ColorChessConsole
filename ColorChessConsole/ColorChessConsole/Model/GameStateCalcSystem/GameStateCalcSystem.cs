using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChessConsole;
class GameStateCalcSystem
{
    public static Map UpdateGameState(Map gameState)
    {

        return gameState;
    }

    public static Map ApplyStep(Map _gameState, Step step)
    {
        Map gameState = new Map(_gameState);

        return gameState;
    }

    public static Map UpdateGameStateForBuilder(Map gameState)
    {
        int x = 0;
        int y = 0;

        //Перебираем игроков
        for (int i = 0; i < gameState.players.Count; i++)
        {
            //Перебираем фигуры игроков
            for (int j = 0; j < gameState.players[i].figures.Count; j++)
            {
                //Получаем координаты на которых стоит фигура
                x = gameState.players[i].figures[j].pos.X;
                y = gameState.players[i].figures[j].pos.Y;

                //Присваиваем клетке ссылку на фигуру 
                gameState.cells[x, y].figure = gameState.players[i].figures[j];
                //Присваиваем клетке номер игрока
                gameState.cells[x, y].numberPlayer = gameState.players[i].number;

                //Тут клеткам присваиваем статус закрашенная, пока нет фигур которые
                //сразу захватывают клетку, изменим, если появятся
                gameState.cells[x, y].type = CellType.Paint;
            }

        }

        return gameState;
    }
}
