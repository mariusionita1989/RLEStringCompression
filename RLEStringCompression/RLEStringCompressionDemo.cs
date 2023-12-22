using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System.Text;

namespace RLEStringCompression
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class RLEStringCompressionDemo
    {
        private const int length = 1024*1024;
        private StringBuilder? sb;
        private string output = string.Empty;

        [GlobalSetup]
        public void GlobalSetup()
        {
            sb = new StringBuilder(length);
        }

        [Benchmark]
        public void RLEBenchmark()
        {
            if (sb != null) 
            {
                output = RLE.Compress(sb.ToString().ToCharArray());
                RLE.Decompress(output);
            } 
        }
    }
}
