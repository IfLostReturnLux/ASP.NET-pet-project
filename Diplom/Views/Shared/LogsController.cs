using Microsoft.AspNetCore.Hosting;
using static Diplom.AppDbContext;
using System.IO;

namespace Diplom.Views.Shared
{
    public static class LogsController
    {
        public static string Path; 

        public static void Logs(string text)
        {
            string logs = File.ReadAllText(Path);
            logs += "\n" + text + ": " + DateTime.Now;
            File.WriteAllText(Path, logs);
        }
    }
}
