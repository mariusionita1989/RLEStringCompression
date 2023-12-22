using System.Runtime.CompilerServices;
using System.Text;

namespace RLEStringCompression
{
    public static class RLE
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Compress(char[] data)
        {
            if (data == null || data.Length == 0)
                return "";

            StringBuilder encodedData = new StringBuilder();
            char currentChar = data[0];
            int count = 1;

            // Process data in chunks
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] == currentChar)
                {
                    count++;
                }
                else
                {
                    encodedData.Append(count).Append(currentChar);
                    currentChar = data[i];
                    count = 1;
                }

                // Process in chunks of size 'chunkSize'
                int chunkSize = 2048; // Adjust the chunk size as needed
                if (i % chunkSize == 0)
                {
                    encodedData.Append('/'); // Use a delimiter to separate chunks
                }
            }

            // Add remaining data
            encodedData.Append(count).Append(currentChar);

            return encodedData.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Decompress(string encodedData)
        {
            if (string.IsNullOrEmpty(encodedData))
                return "";

            StringBuilder decodedData = new StringBuilder();
            int index = 0;

            while (index < encodedData.Length)
            {
                char currentChar = encodedData[index++];
                int count = 0;
                while (index < encodedData.Length && char.IsDigit(encodedData[index]))
                {
                    count = count * 2048 + (encodedData[index++] - '0');
                }

                while (count > 0)
                {
                    decodedData.Append(currentChar);
                    count--;
                }

                // Skip delimiter if present
                if (index < encodedData.Length && encodedData[index] == '/')
                    index++;
            }

            return decodedData.ToString();
        }
    }
}
