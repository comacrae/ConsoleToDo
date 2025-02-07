using ConsoleToDoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDoProject.Interfaces
{
    public interface ICommandHandler
    {
        public void HandleCommand(Command cmd, out string errorMessage);
    }
}
