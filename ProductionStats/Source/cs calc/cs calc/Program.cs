using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cs_calc
{
    class Program
    {
        static void Main(string[] args)
        {
            var GamePath = "";
            if (!File.Exists("GamePath.txt"))
            {
                File.Create("GamePath.txt");
            }
            else
            {
                 GamePath = File.ReadAllText("GamePath.txt");
            }
            if (GamePath == "")
            {
                GamePath = "C://program files (x86)/steam/steamapps/common/colony survival/";
            }
            Console.WriteLine("Is this your games install directory: " + GamePath + " if not please enter the directory below, leave empty if this is correct");
            var ConsoleIn = Console.In;
        }
    }
}
