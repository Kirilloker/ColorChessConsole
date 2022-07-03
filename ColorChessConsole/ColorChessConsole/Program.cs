using ColorChessConsole;

MediatorController mediatorController = MediatorController.Instance();

CellController cellController = new CellController();

GameController gameController = new GameController();

mediatorController.setController(cellController);
mediatorController.setController(gameController);

CellView cell = new CellView(new Position(5,6), cellController);
cellController.setCell(cell);

cell.OnMouseClick();



int[,] nums2 = { { 1, 2, 3}, { 4, 5, 6 } };


foreach (var item in nums2)
{
    Console.WriteLine(item);
}

