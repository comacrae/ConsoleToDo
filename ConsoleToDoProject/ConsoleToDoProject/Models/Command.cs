using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDoProject.Models
{
    public class Command
    {
        public string Name { get; set; } = "Default";
        public List<string> Arguments { get; set; } = new List<string>();

        public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();
    }
}
