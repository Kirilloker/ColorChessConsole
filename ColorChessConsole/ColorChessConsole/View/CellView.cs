namespace ColorChessConsole;

class CellView
{
    Cell cellModel;

    public CellView(Cell _cellModel)
    {
        cellModel = _cellModel;
    }

    public void OnMouseClick()
    {
        cellModel.Click();
    }
    
    //public void ChangeView()
    //{

    //}

    public void StatePrompt(bool state)
    {
        //Prompt.Mesh(state);
    }
}
