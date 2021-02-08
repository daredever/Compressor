using System;
using System.IO;
using Xunit;

namespace Compressor.GZip.Tests
{
    public class CompressorIntegrationTests
    {
        [Fact]
        public void Compress_Decompress_Test()
        {
            var title = Guid.NewGuid().ToString();
            var original = new FileInfo($"{title}_original.txt");
            var decompressed = new FileInfo($"{title}_decompressed.txt");
            var compressed = new FileInfo($"{title}_compressed.txt.gz");
            
            try
            {
                // Arrange
                var expected = Guid.NewGuid().ToString();
                using (var sw = original.CreateText())
                {
                    sw.Write(expected);
                }

                // Act
                var compressor = new GZipFileCompressor(original, compressed);
                compressor.Run();
                var decompressor = new GZipFileDecompressor(compressed, decompressed);
                decompressor.Run();

                // Assert
                Assert.Equal(expected, File.ReadAllText(original.FullName));
                Assert.True(compressed.Length > 0);
                Assert.Equal(expected, File.ReadAllText(decompressed.FullName));
            }
            finally
            {
                original.Delete();
                decompressed.Delete();
                compressed.Delete();
            }
        }
    }
}