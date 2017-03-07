using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {

            var sentences = "hello how are you? I am good. that's good.";
            foreach (var sentence in sentences.TrimEnd('.').Split('.','?',','))
               
            Console.WriteLine((sentence.Trim().Split(' ').Count()));
    
            Console.ReadLine();

        }
    }
}
