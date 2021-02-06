using System;
using CommandLine;

namespace Compressor.Tool
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            return Parser.Default
                .ParseArguments<CompressOptions, DecompressOptions>(args)
                .MapResult(
                    (CompressOptions options) => Compress(options),
                    (DecompressOptions options) => Decompress(options),
                    errors => 1);
        }

        private static int Compress(CompressOptions options)
        {
            var compressor = new FileCompressor();
            compressor.Run();
            return 0;
        }

        private static int Decompress(DecompressOptions options)
        {
            var decompressor = new FileDecompressor();
            decompressor.Run();
            return 0;
        }
    }

    internal class FileCompressor
    {
        public void Run()
        {
            throw new NotImplementedException();
        }
    }

    internal class FileDecompressor
    {
        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}