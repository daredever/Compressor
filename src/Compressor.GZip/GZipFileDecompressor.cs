using System;
using System.IO;
using System.IO.Compression;
using Compressor.Logging;
using Compressor.Validators;

namespace Compressor.GZip
{
    public sealed class GZipFileDecompressor : FileProcessorBase
    {
        public GZipFileDecompressor(FileInfo inputFile, FileInfo outputFile)
        {
            DecompressingValidators.ValidateInputFile(inputFile);
            DecompressingValidators.ValidateOutputFile(outputFile);
            InputFile = inputFile;
            OutputFile = outputFile;
        }

        public override void Run()
        {
            Decompress();
            Log.Info($"Decompressed: {InputFile.Name}");
        }

        private void Decompress()
        {
            using var originalFileStream = InputFile.OpenRead();
            using var decompressedFileStream = File.Create(OutputFile.FullName);
            using var decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress);
            decompressionStream.CopyTo(decompressedFileStream);
        }
    }
}