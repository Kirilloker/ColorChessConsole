using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChessConsole;
interface ICommandInvoker
{
    void SetCommand(ICommand command);
    void SendCommand();
}