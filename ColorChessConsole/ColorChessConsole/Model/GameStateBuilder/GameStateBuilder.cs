using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChessConsole;

class GameStateBuilder
{
    private Map gameState;

    private FigureBuilderDirector figureBuilder;
    private PlayerBuilder playerBuilder;
    private CellBuilder cellBuilder;


    private PlayersDiscription playersDiscription;
    private CellDiscription board;
    private List<FigureSetDiscription>? figureSets;

    public GameStateBuilder()
    { 
        gameState = new Map();

        figureBuilder = new FigureBuilderDirector();
        playerBuilder = new PlayerBuilder();
        cellBuilder = new CellBuilder();
    }

    public Map CreateGameState()
    {
        //Создаем игроков
        for(int i = 0; i < playersDiscription.PlayerNumbers.Count; i++)
        {
            gameState.players.Add(playerBuilder.MakePlayer(
                playersDiscription.PlayerCorners[i],
                playersDiscription.PlayerColors[i],
                playersDiscription.PlayerTypes[i],
                playersDiscription.PlayerNumbers[i]));
        }

        gameState.players.
        return gameState;
    }

    public void SetStandartBoard()
    {
        board.width = 9;
        board.lenght = 9;
        board.PlayerNumbers = new int[,]
        {
            {-1, 0, 0, 0, -1, -1, -1, -1, -1},
            { 0, 0, 0, -1, -1, -1, -1, -1, -1},
            { 0, 0, 1, -1, -1 ,-1, -1 , -1, -1},
            { 0,-1, -1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1, -1, 1},
            {-1, -1, -1, -1, -1, -1, -1, 1, 1},
            {-1, -1, -1, -1, -1, -1, 1, 1, 1},
            {-1, -1, -1, -1, -1, 1, 1, 1, -1},
        };

        board.CellTypes = new CellType[,]
            {{CellType.Empty }
            };
    }

    
}
