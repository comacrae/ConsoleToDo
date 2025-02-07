using ConsoleToDoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDoProject.Interfaces
{
    internal interface ICommandExecutor
    {
        public void Execute(Command cmd);
    }
}
