namespace CollegeApp.MyLogging
{
  public class LogToServerMemory : IMyLogger
  {
    public void Log(string message)
    {
      Console.WriteLine(message);
      Console.WriteLine("Log to Server Memory");
      //Write own logic to save the /
    }
  }
}