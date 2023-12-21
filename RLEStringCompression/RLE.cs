using System.Runtime.CompilerServices;
using System.Text;

namespace RLEStringCompression
{
    public static class RLE
    {
        // the fastest
        #region V1
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CompressV1(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            int length = input.Length;
            var compressed = new StringBuilder(length * 2);

            int i = 0;
            while (i < length)
            {
                char currentChar = input[i];
                int count = 1;

                // Incrementing 'i' separately for efficiency
                int nextIndex = i + 1;
                while (nextIndex < length && input[nextIndex] == currentChar)
                {
                    count++;
                    nextIndex++;
                }

                compressed.Append(count).Append(currentChar);
                i = nextIndex;
            }

            return compressed.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string DecompressV1(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            int length = input.Length;
            var decompressed = new StringBuilder(length);

            int i = 0;
            while (i < length)
            {
                int count = input[i] - '0';
                char character = input[i + 1];

                // Ensure the capacity in chunks to minimize reallocations
                decompressed.EnsureCapacity(decompressed.Length + (count << 2));

                for (int j = 0; j < count; j++)
                    decompressed.Append(character);

                i += 2;
            }

            return decompressed.ToString();
        }
        #endregion
    }
}
