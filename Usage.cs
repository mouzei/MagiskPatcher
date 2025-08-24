using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagiskPatcher
{
    public static class Usage
    {
        public static void Print()
        {
            Console.WriteLine($"" +
                $"电脑面具修补boot工具 MagiskPatcher\r\n" +
                $"by 酷安@某贼 xda@SYXZ\r\n" +
                $"{Patcher.Version}\r\n" +
                $"开源地址：\r\n" +
                $"https://github.com/mouzei/MagiskPatcher\r\n" +
                $"基础用法：\r\n" +
                $"MagiskPatcher.exe 面具zip或apk路径 需要修补的boot文件路径\r\n" +
                $"可选参数：\r\n" +
                $"-out=指定新boot文件路径（包括文件名），默认保存在与原boot相同目录\r\n" +
                $"-wd=指定工作目录（临时文件保存目录），默认为当前目录\r\n" +
                $"-7z=指定7z.exe路径，默认为当前目录\\7z.exe\r\n" +
                $"-mb=指定magiskboot.exe路径，默认为当前目录\\magiskboot.exe\r\n" +
                $"-cfg=指定配置文件路径，默认为当前目录\\MagiskPatcher.csv\r\n" +
                $"-fa=开机时是否安装完整MagiskAPP（即集成完整APP到boot，要求分区空间足够），默认为false\r\n" +
                "-cs=修补成功后检查新boot文件大小，大于设定值则报错。默认为空（不检查），可设为数字或{OrigSize}（原boot文件大小）\r\n" +
                $"-cl=修补成功后是否自动清理工作目录，默认为true\r\n" +
                $"-cpu=指定修补boot的目标处理器，可选项包括arm_64，arm_32，x86_64，x86_32，riscv_64，默认为arm_64\r\n" +
                $"-kv=指定KEEPVERITY标记，默认为true\r\n" +
                $"-kfe=指定KEEPFORCEENCRYPT标记，默认为true\r\n" +
                $"-rm=指定RECOVERYMODE标记，默认为false\r\n" +
                $"-pvf=指定PATCHVBMETAFLAG标记，默认为false\r\n" +
                $"-ls=指定LEGACYSAR标记，默认为false\r\n" +
                $"-pd=指定PREINITDEVICE标记，默认为空\r\n");
            Environment.Exit(1);
        }




    }
}
