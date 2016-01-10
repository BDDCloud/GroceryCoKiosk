namespace GroceryCo.Kiosk.Console
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string line)
        {
            System.Console.WriteLine(line);
        }
    }
}