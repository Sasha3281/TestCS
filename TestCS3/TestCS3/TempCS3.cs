using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TestCS3
{
    class TempCS3
    {
        public static void TempMain()
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
                    //string str = File.ReadAllText(input, Encoding.GetEncoding ("Windows-1251"));
                    string str = File.ReadLines(input, Encoding.GetEncoding("Windows-1251")).FirstOrDefault();
                    Console.WriteLine(str);
                    try
                    {
                        Log log = GetLog(str);

                        string output = input.Replace(".txt", "New.txt");
                        WriteLogToFile(output, log);
                    }
                    catch (ProblemsException pex)
                    {
                        //problems.txt
                        Console.WriteLine("Error: " + pex.Message);
                        //string path = Path.GetDirectoryName(input);
                        string path = input.Replace(".txt", "Problems.txt");
                        Console.WriteLine(path);
                        File.WriteAllText(path, str);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
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
                    throw new Exception("Невалидная входная запись");
            }

            return outlev;
        }

        private static Log ProcessStrType1(string str)
        {
            Log lg = new Log();

            string[] parts = str.Split(new char[] { ' ' }, 3);

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

            if (parts.Length != 5) throw new Exception("Невалидная входная запись");

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
                throw new Exception("Невалидная входная запись");
            }
            log.Date = dt;

            return log;
        }

        private static void WriteLogToFile(string path, Log lg)
        {
            string outstr = "";

            outstr += lg.Date.ToShortDateString();
            outstr += "\t" + lg.Time;
            outstr += "\t" + lg.Level;
            outstr += "\t" + lg.Method;
            outstr += "\t" + lg.Message;

            Console.WriteLine(outstr);
            File.WriteAllText(path, outstr);
        }
    }
}
