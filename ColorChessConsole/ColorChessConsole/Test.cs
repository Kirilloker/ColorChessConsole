using ColorChessConsole.PRINTER;

namespace ColorChessConsole;

static public class Test
{

	public static List<List<Cell>> TestGetAvaible(Map map, int numberPlayer)
    {
		List<List<Cell>> avaiblePlayer = new List<List<Cell>>();
		Player player = map.players[numberPlayer];

        foreach (Figure figure in player.figures)
        {
			avaiblePlayer.Add(WayCalcSystem.CalcAllSteps(map, figure));
		}

        


		return avaiblePlayer;
    }

    // Написать функцию, которая обработает доску 
    // То есть - изменит состояние клеток и всякое такое
}

public class TestAI
{
	static int MAX_LEVEL = 4;
	public static int AlphaBeta(Map map, int level, int alpha, int beta)
    {
		List<List<Cell>> avaible = new List<List<Cell>>();
		int MaxMinEvaluation = 0;
		Cell bestCell = new Cell(new Position(-1,-1));
		Figure bestFigure = new Figure();

		//int statusGame = 0;
		//if (statusGame == 1) { return 10000;  }
		//else if (statusGame == 2) { return -10000; }

		if (level >= MAX_LEVEL)
		{
			return evaluation_function(map);
		}


		if (level % 2 == 0)
		{
			avaible = Test.TestGetAvaible(map, 1);
			MaxMinEvaluation = int.MinValue;


			for (int i = 0; i < avaible.Count; i++)
			{
				if (beta < alpha) break;

				for (int j = 0; j < avaible[i].Count; j++)
				{
					if (MaxMinEvaluation > beta) break;
					if (beta < alpha) break;


					Map copyMap = GameStateCalcSystem.ApplyStep(map, map.players[1].figures[i], avaible[i][j]);

					int MinMax = AlphaBeta(copyMap, level + 1, alpha, beta);

					if (level == 0 && MinMax > MaxMinEvaluation)
					{
						bestCell = avaible[i][j];
						bestFigure = map.players[1].figures[i];
					}

					MaxMinEvaluation = Math.Max(MaxMinEvaluation, MinMax);
					alpha = Math.Max(alpha, MaxMinEvaluation);
				}
			}
		}
        else
        {
			avaible = Test.TestGetAvaible(map, 0);
			MaxMinEvaluation = int.MaxValue;

			for (int i = 0; i < avaible.Count; i++)
			{
				if (beta < alpha) break;

				for (int j = 0; j < avaible[i].Count; j++)
				{
					if (MaxMinEvaluation < alpha) break;
					if (beta < alpha) break;


					Map copyMap = GameStateCalcSystem.ApplyStep(map, map.players[0].figures[i], avaible[i][j]);

					int MinMax = AlphaBeta(copyMap, level + 1, alpha, beta);

					MaxMinEvaluation = Math.Min(MaxMinEvaluation, MinMax);
					beta = Math.Min(alpha, MaxMinEvaluation);
				}
			}
		}

		if (level == 0)
        {
            Console.WriteLine("Самый лучший ход:" + bestCell);
            Console.WriteLine("Figure:" + bestFigure);
        }


		return MaxMinEvaluation;
	}


	public static int evaluation_function(Map map) 
	{
		return map.scorePlayer[0] + map.scorePlayer[1]; 
	}
}


/*

int AI::alpha_beta(Board _board, int level, int alpha, int beta)
{
	// Все возможные ходы
	vector<pair<Point, vector<Point>>> avaible;
	// Оценка минимакса
	int max_min_evaluation;
	// Лучший ход
	pair<Point, Point> best;

	// Если спустились на глубину равной максимальной, или игра уже закончена
	int status_game = _board.check_status_game();

	if (status_game == 2)
	{
	 	return 10000;
	}
	else if (status_game == 1)
	{
	 	return -10000;
	}
	if (level >= MAX_LEVEL)
	{
		 	return evaluation_function(_board);
	}
	if (level % 2 == 0)
	{
	 	// Сейчас ходит бот
	 	avaible = _board.get_avaible(2);
	 	max_min_evaluation = INT16_MIN;
	 	for (size_t i = 0; i < avaible.size(); i++)
	 	{
			 		if (beta < alpha)
				 		break;
			 	 	for (size_t j = 0; j < avaible[i].second.size(); j++)
			 	 	{
				 		 	if (max_min_evaluation >= beta) break;
	 		 	if (beta < alpha) break;
	 		 	// Создаем виртуальную доску
	 		 	Board fake_board(_board);
	 		 	// Делаем ход 
	 		 	fake_board.move(pair<Point, Point>(avaible[i].first, avaible[i].second[j]));
	 		 	int _min_max = alpha_beta(fake_board, level + 1, alpha, beta);
				 		 	// Если мы в корне дерева, запоминаем наилучший ход
					 		 	if (level == 0 && _min_max > max_min_evaluation)
	 		 	{
	 			 	best = pair<Point, Point>(avaible[i].first, avaible[i].second[j]);
	 		 	}
	 		 	max_min_evaluation = max(max_min_evaluation, _min_max);
				  		 	alpha = max(alpha, max_min_evaluation);
			 		}
	 	}
	}
	else 
	{
		 	// Сейчас ходит Человек
	 	avaible = _board.get_avaible(1);
	 	max_min_evaluation = INT16_MIN;
	 	for (size_t i = 0; i < avaible.size(); i++)
	 	{
			 		if (beta < alpha)
				 		break;
			 	 	for (size_t j = 0; j < avaible[i].second.size(); j++)
			 	 	{
				 		 	if (max_min_evaluation <= alpha) break;
	 		 	if (beta < alpha) break;
	 		 	// Создаем виртуальную доску
	 		 	Board fake_board(_board);
	 		 	// Делаем ход 
	 		 	fake_board.move(pair<Point, Point>(avaible[i].first, avaible[i].second[j]));
	 		 	int _min_max = alpha_beta(fake_board, level + 1, alpha, beta);
	 		 	max_min_evaluation = min(max_min_evaluation, _min_max);
				  		 	beta = min(alpha, max_min_evaluation);
			 		}
	 	}
	}
	// Когда вернулись на начальный уровень рекурсии
	if (level == 0)
	{
		 	// Устанавливаем лучший ход
		 	info_step = best;
	}
	return max_min_evaluation;
}


 */