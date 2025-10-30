namespace Command_line
{
    public static class ArgumentParser
    {
        public static Dictionary<string, string> Parse(string[] args)
        {
            var argsDictionary = new Dictionary<string, string>();
            if (args == null || args.Length == 0) return argsDictionary;

            int NecessaryArgsIndex = 1;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Length == 0) continue;
                if (args[i][..1] != "-")
                {
                    argsDictionary.Add($"args{NecessaryArgsIndex}", args[i]);
                    NecessaryArgsIndex += 1;
                }
                else
                {
                    string argtmp = args[i][1..];
                    if (argtmp.Length == 0) continue;
                    if (argtmp[..1] != "=" && argtmp[..1] != " ")
                    {
                        int equalcount = argtmp.Count(c => c == '=');
                        if (equalcount == 0)
                        {
                            argsDictionary.Add($"args_{argtmp}", "y");
                        }
                        else
                        {
                            var parts = argtmp.Split(new[] { '=' }, 2);
                            var left = parts[0];
                            var right = parts.Length > 1 ? parts[1] : string.Empty;
                            argsDictionary.Add($"args_{left}", right);
                        }
                    }
                    else
                    {
                        argsDictionary.Add($"invalidArgs{i}", argtmp);
                    }
                }
            }

            return argsDictionary;
        }

        public static void PrintParsedArguments(Dictionary<string, string> dict)
        {
            if (dict == null || dict.Count == 0)
            {
                Console.WriteLine("::No argument");
                return;
            }
            foreach (var pair in dict)
            {
                if (pair.Key.StartsWith("args"))
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
}
