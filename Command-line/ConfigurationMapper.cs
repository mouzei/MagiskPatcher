using MagiskPatcher;

namespace Command_line
{
    public static class ConfigurationMapper
    {
        public static PatcherConfig MapFromArguments(Dictionary<string, string> args)
        {
            var cfg = new PatcherConfig();
            if (args == null) return cfg;
            foreach (var pair in args)
            {
                var k = pair.Key;
                var v = pair.Value;
                if (k == "args1") cfg.MagiskZipPath = v;
                else if (k == "args2") cfg.OrigFilePath = v;
                else if (k == "args_out") cfg.NewFilePath = v;
                else if (k == "args_wd") cfg.WorkDir = v;
                else if (k == "args_7z") cfg.ZipToolPath = v;
                else if (k == "args_mb") cfg.MagiskbootPath = v;
                else if (k == "args_cfg") cfg.CsvConfPath = v;
                else if (k == "args_fa") cfg.InstFullMagsikAPP = bool.TryParse(v, out var fa) ? fa : (bool?)null;
                else if (k == "args_cs") cfg.ChkNewFileSize = v;
                else if (k == "args_cl") cfg.CleanupAfterComplete = bool.TryParse(v, out var cl) ? cl : (bool?)null;
                else if (k == "args_si") cfg.SaveSomeOutputInfoToBat = v;
                else if (k == "args_cpu") cfg.CpuType = v;
                else if (k == "args_kv") cfg.Flag_KEEPVERITY = bool.TryParse(v, out var kv) ? kv : (bool?)null;
                else if (k == "args_kfe") cfg.Flag_KEEPFORCEENCRYPT = bool.TryParse(v, out var kfe) ? kfe : (bool?)null;
                else if (k == "args_rm") cfg.Flag_RECOVERYMODE = bool.TryParse(v, out var rm) ? rm : (bool?)null;
                else if (k == "args_pvf") cfg.Flag_PATCHVBMETAFLAG = bool.TryParse(v, out var pvf) ? pvf : (bool?)null;
                else if (k == "args_ls") cfg.Flag_LEGACYSAR = bool.TryParse(v, out var ls) ? ls : (bool?)null;
                else if (k == "args_pd") cfg.Flag_PREINITDEVICE = v;
            }
            return cfg;
        }
    }
}
