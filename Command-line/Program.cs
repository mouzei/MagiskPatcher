using MagiskPatcher;

namespace Command_line
{
    /// <summary>
    /// 命令行程序主入口
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 解析命令行参数
                var argumentDict = ArgumentParser.Parse(args);

                // 检查是否需要显示帮助
                if (args.Length == 0 || argumentDict.ContainsKey("args_h"))
                {
                    UsageDisplay.PrintUsage();
                    Environment.Exit(1);
                    return;
                }

                // 显示解析的参数
                ArgumentParser.PrintParsedArguments(argumentDict);

                // 将参数映射到配置对象
                var config = ConfigurationMapper.MapFromArguments(argumentDict);

                // 验证配置
                var validation = config.Validate();
                if (!validation.IsValid)
                {
                    Console.WriteLine("[Error]配置验证失败:");
                    foreach (var error in validation.Errors)
                    {
                        Console.WriteLine($"  - {error}");
                    }
                    Environment.Exit(1);
                    return;
                }

                // 创建MagiskPatcher实例并执行修补
                var patcher = new MagiskPatcherCore(config);
                var result = patcher.Patch();

                if (result.IsSuccess)
                {
                    Console.WriteLine("[Success]修补成功完成!");
                    if (result.Details is { } details)
                    {
                        Console.WriteLine($"[Info]Magisk版本: {details.MagiskVersion}");
                        Console.WriteLine($"[Info]原始文件大小: {details.OriginalFileSize} bytes");
                        Console.WriteLine($"[Info]新文件大小: {details.NewFileSize} bytes");
                    }
                    if (!string.IsNullOrEmpty(result.Message))
                    {
                        Console.WriteLine($"[Info]{result.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"[Error]修补失败: {result.ErrorMessage}");
                    if (result.Exception is { } ex)
                    {
                        Console.WriteLine($"[Error]异常详情: {ex.Message}");
                    }
                    Environment.Exit(1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error]程序执行出错: {ex.Message}");
                Console.WriteLine($"[Error]堆栈跟踪: {ex.StackTrace}");
                Environment.Exit(1);
            }
        }
    }
}
