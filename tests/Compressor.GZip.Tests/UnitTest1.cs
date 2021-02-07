using System;
using System.IO;
using Xunit;

namespace Compressor.GZip.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var uncompressed = new FileInfo("test.txt");
            var compressed = new FileInfo("test.txt.gz");
            compressed.Delete();
            
            using (var sw = uncompressed.CreateText())
            {
                sw.Write("text");
            }

            Assert.True(uncompressed.Exists);
            Assert.False(compressed.Exists);

            var compressor = new GZipFileCompressor(uncompressed, compressed);
            compressor.Run();
            uncompressed.Delete();

            Assert.False(uncompressed.Exists);
            Assert.True(compressed.Exists);

            var decompressor = new GZipFileDecompressor(compressed, uncompressed);
            decompressor.Run();
            compressed.Delete();

            Assert.True(uncompressed.Exists);
            Assert.False(compressed.Exists);
        }
    }
}