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
        private const int length = 1024 * 1024 * 32;
        private StringBuilder? sb;
        private string output = string.Empty;

        [GlobalSetup]
        public void GlobalSetup()
        {
            sb = new StringBuilder(length);
        }

        [Benchmark(Baseline = true)]
        public void RLE_V1()
        {
            if (sb != null) 
            {
                output = RLE.CompressV1(sb.ToString());
                RLE.DecompressV1(output);
            } 
        }
    }
}
