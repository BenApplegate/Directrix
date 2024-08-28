/*********************************
 * Author(s): Benjamin Applegate
 * Created: August 28, 2024
 * Last Updated: August 28, 2024
 ********************************/

namespace Directrix.Utility;

public static class Logger
{
    //Verbose logging signifies that all messages should be print to console, not just those marked as important
    private static bool _verbose;
    private static Thread _thread;

    /// <summary>
    /// Initializes Logger class by starting Logger thread and setting up initial resources
    /// </summary>
    /// <param name="verbose">Enables or disables verbose logging</param>
    public static void Init(bool verbose = true)
    {
        _verbose = verbose;

        _thread = new Thread(LoggerThread);
        _thread.Name = "LoggerThread";
        _thread.Start();
    }

    private static void LoggerThread()
    {
        Console.WriteLine("Logger Initiated");
    }
}