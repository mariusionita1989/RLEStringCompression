using BenchmarkDotNet.Running;

namespace RLEStringCompression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<RLEStringCompressionDemo>();
        }
    }
}
