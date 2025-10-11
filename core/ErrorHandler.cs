namespace uml_diagram.core;

public static class ErrorHandler
{
    
    public static void CatchError(Exception ex)
    {
        ErrorMessage frm = new ErrorMessage(ex.Message);
        frm.ShowMessage();
        
        string logPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..", @"src\logs"));

        using (var sw = new StreamWriter(Path.Combine(logPath, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log")))
        {
            sw.WriteLine("=======================================");
            sw.WriteLine($"🕒 Time: {DateTime.Now}");
            sw.WriteLine($"💥 Exception Type: {ex.GetType().FullName}");
            sw.WriteLine($"📄 Message: {ex.Message}");
            sw.WriteLine($"🔗 HelpLink: {ex.HelpLink ?? "null"}");
            sw.WriteLine($"📦 Source: {ex.Source ?? "unknown"}");
            sw.WriteLine($"🧠 Data: {(ex.Data?.Count > 0 ? string.Join(", ", ex.Data.Keys) : "none")}");
            sw.WriteLine();
            sw.WriteLine("🔍 Stack Trace:");
            sw.WriteLine(ex.StackTrace);
            sw.WriteLine("=======================================");
        }
    }
}