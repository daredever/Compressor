using System;
using System.IO;
using CommandLine;
using Compressor.GZip;
using Compressor.Logging;

namespace Compressor.Tool
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new ConsoleLogger();
            return Parser.Default
                .ParseArguments<CompressOptions, DecompressOptions>(args)
                .MapResult(
                    (CompressOptions options) => Compress(options),
                    (DecompressOptions options) => Decompress(options),
                    errors => 1);
        }

        private static int Compress(CompressOptions options)
        {
            try
            {
                var inputFile = new FileInfo(options.InputFile);
                var outputFile = new FileInfo(options.OutputFile);
                var compressor = new GZipFileCompressor(inputFile, outputFile);
                compressor.Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return 1;
            }
        }

        private static int Decompress(DecompressOptions options)
        {
            try
            {
                var inputFile = new FileInfo(options.InputFile);
                var outputFile = new FileInfo(options.OutputFile);
                var decompressor = new GZipFileDecompressor(inputFile, outputFile);
                decompressor.Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return 1;
            }
        }
    }
}