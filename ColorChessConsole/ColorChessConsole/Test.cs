using ColorChessConsole.PRINTER;
using System;
using System.Collections;

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
			bestCell1 = bestCell;
			bestFigure1 = bestFigure; 
		}


		return MaxMinEvaluation;
	}

	public static Cell bestCell1 = null;
	public static Figure bestFigure1 = null;


	public static int evaluation_function(Map map) 
	{
		return - map.scorePlayer[0] + map.scorePlayer[1]; 
	}
}




class Example
{
	public static void Main()
	{
		// Create a new hash table.
		//
		Hashtable openWith = new Hashtable();

		// Add some elements to the hash table. There are no
		// duplicate keys, but some of the values are duplicates.
		openWith.Add(new Map(), 2);
		openWith.Add("bmp", "paint.exe");
		openWith.Add("dib", "paint.exe");
		openWith.Add("rtf", "wordpad.exe");

		// The Add method throws an exception if the new key is
		// already in the hash table.
		try
		{
			openWith.Add("txt", "winword.exe");
		}
		catch
		{
			Console.WriteLine("An element with Key = \"txt\" already exists.");
		}

		// The Item property is the default property, so you
		// can omit its name when accessing elements.
		Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);

		// The default Item property can be used to change the value
		// associated with a key.
		openWith["rtf"] = "winword.exe";
		Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);

		// If a key does not exist, setting the default Item property
		// for that key adds a new key/value pair.
		openWith["doc"] = "winword.exe";

		// ContainsKey can be used to test keys before inserting
		// them.
		if (!openWith.ContainsKey("ht"))
		{
			openWith.Add("ht", "hypertrm.exe");
			Console.WriteLine("Value added for key = \"ht\": {0}", openWith["ht"]);
		}

		// When you use foreach to enumerate hash table elements,
		// the elements are retrieved as KeyValuePair objects.
		Console.WriteLine();
		foreach (DictionaryEntry de in openWith)
		{
			Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
		}

		// To get the values alone, use the Values property.
		ICollection valueColl = openWith.Values;

		// The elements of the ValueCollection are strongly typed
		// with the type that was specified for hash table values.
		Console.WriteLine();
		foreach (string s in valueColl)
		{
			Console.WriteLine("Value = {0}", s);
		}

		// To get the keys alone, use the Keys property.
		ICollection keyColl = openWith.Keys;

		// The elements of the KeyCollection are strongly typed
		// with the type that was specified for hash table keys.
		Console.WriteLine();
		foreach (string s in keyColl)
		{
			Console.WriteLine("Key = {0}", s);
		}

		// Use the Remove method to remove a key/value pair.
		Console.WriteLine("\nRemove(\"doc\")");
		openWith.Remove("doc");

		if (!openWith.ContainsKey("doc"))
		{
			Console.WriteLine("Key \"doc\" is not found.");
		}
	}
}

/* This code example produces the following output:

An element with Key = "txt" already exists.
For key = "rtf", value = wordpad.exe.
For key = "rtf", value = winword.exe.
Value added for key = "ht": hypertrm.exe

Key = dib, Value = paint.exe
Key = txt, Value = notepad.exe
Key = ht, Value = hypertrm.exe
Key = bmp, Value = paint.exe
Key = rtf, Value = winword.exe
Key = doc, Value = winword.exe

Value = paint.exe
Value = notepad.exe
Value = hypertrm.exe
Value = paint.exe
Value = winword.exe
Value = winword.exe

Key = dib
Key = txt
Key = ht
Key = bmp
Key = rtf
Key = doc

Remove("doc")
Key "doc" is not found.
 */

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