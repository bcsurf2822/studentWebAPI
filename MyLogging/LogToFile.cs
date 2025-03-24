namespace CollegeApp.MyLogging
{
  public class LogToFile : IMyLogger
  {
    public void Log(string message)
    {
      Console.WriteLine(message);
      Console.WriteLine("Log To File");
      //Write own logic to save the /
    }
  }
}