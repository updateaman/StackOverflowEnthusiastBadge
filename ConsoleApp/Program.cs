using System.IO;
using System.Reflection;
using StackOverflowEnthusiastBadge;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var loginTests = new LoginTests();
            loginTests.MyTest(path);
        }
    }
}
