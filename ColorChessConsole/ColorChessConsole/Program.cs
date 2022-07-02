using ColorChessConsole;

MediatorController mediatorController = MediatorController.Instance();

CellController cellController = new CellController();

GameController gameController = new GameController();

mediatorController.setController(cellController);
mediatorController.setController(gameController);

CellView cell = new CellView(new Position(5,6), cellController);
cellController.setCell(cell);

cell.OnMouseClick();

