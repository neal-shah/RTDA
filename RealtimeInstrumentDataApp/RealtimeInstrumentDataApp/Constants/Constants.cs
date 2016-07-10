using System.IO;
using System.Reflection;

namespace RealtimeInstrumentDataApp

{
    public class Constants

    {

        public static string File = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\Sample Data.txt");

    }

}