namespace Command_line
{
    public static class UsageDisplay
    {
        public static void PrintUsage()
        {
            Console.WriteLine($"" +
                $"电脑面具修补boot工具 MagiskPatcher\r\n" +
                $"by 酷安@某贼 xda@SYXZ\r\n" +
                $"(embedded CLI)\r\n" +
                $"基础用法：\r\n" +
                $"MagiskPatcher.exe 面具zip或apk路径需要修补的boot文件路径\r\n" +
                $"可选参数：\r\n" +
                $"-out=指定新boot文件路径（包括文件名），默认保存在与原boot相同目录\r\n" +
                $"-wd= 指定工作目录（临时文件保存目录），默认为当前目录\r\n" +
                $"-7z= 指定7z.exe路径，默认为可执行文件同级目录\\7z.exe\r\n" +
                $"-mb= 指定magiskboot.exe路径，默认为可执行文件同级目录\\magiskboot.exe\r\n" +
                $"-cfg= 指定配置文件路径，默认为可执行文件同级目录\\MagiskPatcher.csv（程序会在启动目录查找）\r\n" +
                $"更多选项请查看项目文档\r\n");
        }
    }
}
