using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static MagiskPatcher.Patcher;
using static MagiskPatcher.Program;
using static MagiskPatcher.Tool;

namespace MagiskPatcher
{
    public class Program
    {
        //必须参数
        public static string MagiskZipPath;
        public static string OrigFilePath;
        //可选参数-工具
        public static string NewFilePath;
        public static string WorkDir;
        public static string ZipToolPath;
        public static string MagiskbootPath;
        public static string CsvConfPath;
        //可选参数-修补选项
        public static string CpuType;
        public static bool? Flag_KEEPVERITY;
        public static bool? Flag_KEEPFORCEENCRYPT;
        public static bool? Flag_RECOVERYMODE;
        public static bool? Flag_PATCHVBMETAFLAG;
        public static bool? Flag_LEGACYSAR; //同SYSTEM_ROOT
        public static string Flag_PREINITDEVICE;

        static void Main(string[] args)
        {
            //接收参数
            Dictionary<string, string> argsDictionary = ArgsParser.Run(args, true);
            if (argsDictionary.Count != 0)
            {
                foreach (KeyValuePair<string, string> pair in argsDictionary)
                {
                    if (pair.Key == "args1") { MagiskZipPath = argsDictionary["args1"]; }
                    if (pair.Key == "args2") { OrigFilePath = argsDictionary["args2"]; }
                    if (pair.Key == "args_h") { Usage.Print(); }
                    if (pair.Key == "args_out") { NewFilePath = argsDictionary["args_out"]; }
                    if (pair.Key == "args_wd") { WorkDir = argsDictionary["args_wd"]; }
                    if (pair.Key == "args_7z") { ZipToolPath = argsDictionary["args_7z"]; }
                    if (pair.Key == "args_mb") { MagiskbootPath = argsDictionary["args_mb"]; }
                    if (pair.Key == "args_cfg") { CsvConfPath = argsDictionary["args_cfg"]; }
                    if (pair.Key == "args_cpu") { CpuType = argsDictionary["args_cpu"]; }
                    if (pair.Key == "args_kv")  { Flag_KEEPVERITY = bool.Parse(argsDictionary["args_kv"]); }
                    if (pair.Key == "args_kfe") { Flag_KEEPFORCEENCRYPT = bool.Parse(argsDictionary["args_kfe"]); }
                    if (pair.Key == "args_rm")  { Flag_RECOVERYMODE = bool.Parse(argsDictionary["args_rm"]); }
                    if (pair.Key == "args_pvf") { Flag_PATCHVBMETAFLAG = bool.Parse(argsDictionary["args_pvf"]); }
                    if (pair.Key == "args_ls")  { Flag_LEGACYSAR = bool.Parse(argsDictionary["args_ls"]); }
                    if (pair.Key == "args_pd")  { Flag_PREINITDEVICE = argsDictionary["args_pd"]; }
                }
            }
            else
            {
                Usage.Print();
            }
            //执行修补
            Patcher.Run();

        }
    }



}
