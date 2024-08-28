/*********************************
 * Author(s): Benjamin Applegate
 * Created: August 28, 2024
 * Last Updated: August 28, 2024
 ********************************/

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;

namespace Directrix.Utility;

public static class Logger
{

    /// <summary>
    /// This Enum designates which log level a message should be printed as
    /// </summary>
    private enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error,
    }
    private struct LogMessage
    {
        public LogLevel Level;
        public string Message;
        public MethodBase? Method;
    }
    
    //Verbose logging signifies that all messages should be print to console, not just those marked as important
    private static bool _verbose;
    private static Thread _thread;
    private static ConcurrentQueue<LogMessage> _logMessages;
    private static SemaphoreSlim _semaphore;

    /// <summary>
    /// Initializes Logger class by starting Logger thread and setting up initial resources
    ///
    /// Note: Should only be called from the main thread
    /// </summary>
    /// <param name="verbose">Enables or disables verbose logging</param>
    public static void Init(bool verbose = true)
    {
        //Store the verbose setting
        _verbose = verbose;
        
        //Initialize message queue and semaphore
        _logMessages = new ConcurrentQueue<LogMessage>();
        _semaphore = new SemaphoreSlim(0);
        

        //Ensure that the calling thread is named
        Thread.CurrentThread.Name = "MainThread";
        
        //Start logging thread
        _thread = new Thread(LoggerThread);
        _thread.Name = "LoggerThread";
        _thread.Start();
    }

    /// <summary>
    /// Contains the main code of the logger.
    /// Listens for messages in the queue, and prints them in the correct format
    /// </summary>
    private static void LoggerThread()
    {
        Console.WriteLine("Logger Initiated");
    }

    public static void Debug(string message)
    {
        var method = new StackTrace().GetFrame(1)?.GetMethod();
        var log = new LogMessage { Level = LogLevel.Debug, Message = message, Method = method };
        _logMessages.Enqueue(log);
        _semaphore.Release(1);
    }
}