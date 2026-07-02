using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TestCS3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            while (input != "exit")
            {
                Console.WriteLine();
                Console.WriteLine("Введите путь к файлу или exit для выхода:");
                input = Console.ReadLine();

                //string FilePath = @"D:\Programs\FILES\TestFiles\TestFile1.txt";

                if (File.Exists(input))
                {
                    //List<string> records = File.ReadLines(input, Encoding.GetEncoding("Windows-1251")).ToList();
                    List<string> records = File.ReadLines(input).ToList();
                    List<string> results = new List<string>();
                    List<string> problems = new List<string>();

                    foreach (string record in records)
                    {
                        try
                        {
                            Log log = GetLog(record);
                            results.Add(GetStrFromLog(log));
                        }
                        catch (ProblemsException pex)
                        {
                            problems.Add(record);
                        }
                    }

                    if (results.Count != 0)
                    {
                        string output = input.Replace(".txt", "New.txt");
                        File.WriteAllLines(output, results);
                        Console.WriteLine("Cформирован файл:");
                        Console.WriteLine(output);
                    }

                    if (problems.Count != 0)
                    {
                        string path = Path.GetDirectoryName(input) + "\\problems.txt";
                        File.WriteAllLines(path, problems);
                        Console.WriteLine("Ошибки записаны в файл:");
                        Console.WriteLine(path);
                    }
                }
                else
                {
                    if (input != "exit") Console.WriteLine("Файл не найден");
                }
            }
        }

        private static string SetLevel(string inlev)
        {
            string outlev = "";

            switch (inlev)
            {
                case "INFO":
                case "INFORMATION":
                    outlev = "INFO";
                    break;
                case "WARN":
                case "WARNING":
                    outlev = "WARN";
                    break;
                case "ERROR":
                case "DEBUG":
                    outlev = inlev;
                    break;
                default:
                    throw new ProblemsException("Невалидная входная запись");
            }

            return outlev;
        }

        private static Log ProcessStrType1(string str)
        {
            Log lg = new Log();

            string[] parts = str.Split(new char[] {' '}, 3);

            lg.Time = parts[0];
            lg.Level = SetLevel(parts[1]);
            lg.Method = "DEFAULT";
            lg.Message = parts[2];

            return lg;
        }

        private static Log ProcessStrType2(string str)
        {
            Log lg = new Log();

            string[] parts = str.Split('|');

            if (parts.Length != 5) throw new ProblemsException("Невалидная входная запись");
 
            lg.Time = parts[0];
            lg.Level = SetLevel(parts[1]);
            lg.Method = parts[3]; // parts[2] is skipped
            lg.Message = parts[4];

            return lg;
        }

        private static Log GetLog(string str)
        {
            string datestr = str.Substring(0, 10);
            DateTime dt = DateTime.Parse(datestr);
            str = str.Substring(11);

            int type = 0;
            if (datestr.IndexOf(".") != -1) type = 1;
            else if (datestr.IndexOf("-") != -1) type = 2;

            Log log = new Log();
            if (type == 1)
            {
                log = ProcessStrType1(str);
            }
            else if (type == 2)
            {
                log = ProcessStrType2(str);
            }
            else
            {
                throw new ProblemsException("Невалидная входная запись");
            }
            log.Date = dt;

            return log;
        }

        private static string GetStrFromLog(Log lg)
        {
            string str = "";

            str += lg.Date.ToString("dd-MM-yyyy");
            str += "\t" + lg.Time;
            str += "\t" + lg.Level;
            str += "\t" + lg.Method;
            str += "\t" + lg.Message;

            return str;
        }

        
    }
}
