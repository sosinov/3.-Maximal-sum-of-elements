using SumMaxElement;
using System.IO;
using System.Globalization;
using static SumMaxElement.LinesArrayClass;
using System.Reflection;

namespace Programm 
{
    class Program
    {       
        public static string GetFilePath(string[] args)
        {
            bool pathIsOk = false;
            string? inputData;

            if (args.Length > 0)
            {
                inputData = args[0];
            }
            else
            {
                System.Console.WriteLine("Please input file path:");
                inputData = Console.ReadLine();
            }

            do
            {
                if (File.Exists(inputData))
                {
                    pathIsOk = true;
                    break;
                }
                else
                {
                    System.Console.WriteLine("Invalid directory. Please input correct path:");
                    inputData = Console.ReadLine();
                }
            }
            while (!pathIsOk);

            return inputData;
        }
        public static void Main(string[] args)
        {
            string path = GetFilePath(args);
            LinesArrayClass result = new LinesArrayClass(path);
            if (result.GetMaxSum() != null)
            {
                Console.WriteLine("The maximal sum =  {0}.", result.GetMaxSum());
                Console.WriteLine("Number of lines with wrong elements = {0}.", result.GetWrongElementsNumber().Count);
                foreach (int wrong in result.GetWrongElementsNumber())
                {
                    Console.WriteLine("Wrong elements are in line nr. {0}", wrong);
                }
            }
            else
            {
                Console.WriteLine("File doesn't have any valid input lines.");
            }            
            Console.ReadLine();
        }
    }
}

