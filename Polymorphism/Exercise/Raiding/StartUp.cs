using Raiding.Core;
using Raiding.Core.Contracts;
using Rаiding.IO;
using Rаiding.IO.Contracts;
namespace Rаiding
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}