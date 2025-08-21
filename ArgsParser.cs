using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagiskPatcher
{
    public class ArgsParser
    {
        static string argpart1;
        static string argpart2;
        static Dictionary<string, string> argsDictionary = new Dictionary<string, string> { };

        public static Dictionary<string, string> Run(string[] args, bool printResult)
        {
            if (args.Length == 0)
            {
                //没有参数
            }
            else
            {
                //循环处理所有参数
                int NecessaryArgsIndex = 1;
                for (int i = 0; i < args.Length; i++)
                {
                    //如果参数不是以-开头的（必要的参数），例如xxx.exe args1
                    if (args[i].Substring(0, 1) != "-")
                    {
                        argsDictionary.Add($"args{NecessaryArgsIndex}", $"{args[i]}");
                        //Console.WriteLine($"set \"args{NecessaryArgsIndex}={args[i]}\"");
                        NecessaryArgsIndex += 1;
                    }
                    //如果参数是以-开头的
                    else
                    {
                        //去除-
                        string argtmp = args[i].Substring(1);
                        //格式正确：第一个字符不是-或空格
                        if (argtmp.Substring(0, 1) != "=" && argtmp.Substring(0, 1) != " ")
                        {
                            int equalcount = argtmp.Count(c => c == '=');
                            //如果参数中没有等号，例如xxx.exe -noprompt
                            if (equalcount == 0)
                            {
                                argsDictionary.Add($"args_{argtmp}", $"y");
                                //Console.WriteLine($"set \"args_{argtmp}=y\"");
                            }
                            //如果参数中有等号，例如xxx.exe -noprompt=y
                            else
                            {
                                SplitArg(argtmp);
                                argsDictionary.Add($"args_{argpart1}", $"{argpart2}");
                                //Console.WriteLine($"set \"args_{argpart1}={argpart2}\"");
                            }
                        }
                        //格式错误
                        else
                        {
                            //忽略该参数
                            argsDictionary.Add($"invalidArgs{i}", $"{argtmp}");
                            //Console.WriteLine($"::Ignore invalid argument: {argtmp}");
                        }
                    }
                }
            }
            //参数解析完成，开始输出
            if (printResult)
            {
                if (argsDictionary.Count == 0)
                {
                    Console.WriteLine($"::No argument");
                }
                else
                {
                    foreach (KeyValuePair<string, string> pair in argsDictionary)
                    {
                        if (pair.Key.Substring(0, 4) == "args")
                        {
                            Console.WriteLine($"set \"{pair.Key}={pair.Value}\"");
                        }
                        else
                        {
                            Console.WriteLine($"::Ignore invalid argument: {pair.Value}");
                        }
                    }
                }
            }
            return argsDictionary;

        }








        static void SplitArg(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                argpart1 = "";
                argpart2 = "";
            }

            // 使用Split方法以'='为分隔符分割字符串
            string[] parts = input.Split(new[] { '=' }, 2); // 限制分割为2部分以提高性能

            // 返回第一部分
            argpart1 = parts[0];
            argpart2 = parts[1];
        }




    }
}
