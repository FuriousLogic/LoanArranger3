using System;
using System.Diagnostics;
using System.Linq;

namespace LA3
{
    internal static class Pdf
    {
        public static bool PrintPdf(string pdfPath)
        {
            try
            {
                var proc = new Process
                {
                    StartInfo =
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        Verb = "print",
                        FileName = @"C:\Program Files (x86)\Adobe\Reader 11.0\Reader\AcroRd32.exe",
                        Arguments = $@"/p /h {pdfPath}",
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };


                proc.Start();
                proc.StartInfo.WindowStyle=ProcessWindowStyle.Hidden;
                if (!proc.HasExited)
                    proc.WaitForExit(10000);

                proc.EnableRaisingEvents = true;

                proc.Close();
                if (!KillAdobe("AcroRd32"))
                    throw new Exception("Problem killing Adobe process");
                return true;
            }
            catch (Exception ex)
            {
                Functions.ShowError(ex);
                return false;
            }
        }

        private static bool KillAdobe(string name)
        {
            foreach (var process in Process.GetProcesses().Where(p=>p.ProcessName.StartsWith(name)))
            {
                process.Kill();
                return true;
            }
            return false;
        }
    }
}