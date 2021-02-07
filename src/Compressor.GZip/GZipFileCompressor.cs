using System.IO;
using System.IO.Compression;
using Compressor.Logging;
using Compressor.Validators;

namespace Compressor.GZip
{
    public sealed class GZipFileCompressor : FileProcessorBase
    {
        public GZipFileCompressor(FileInfo inputFile, FileInfo outputFile)
        {
            CompressingValidators.ValidateInputFile(inputFile);
            CompressingValidators.ValidateOutputFile(outputFile);
            InputFile = inputFile;
            OutputFile = outputFile;
        }

        public override void Run()
        {
            if (InputFile.Extension == Constants.GZipFileExtension)
            {
                return;
            }

            Compress();
            Log.Info($"Compressed {InputFile.Name} from {InputFile.Length} to {OutputFile.Length} bytes.");
        }

        private void Compress()
        {
            using var originalFileStream = InputFile.OpenRead();
            using var compressedFileStream = File.Create(OutputFile.FullName);
            using var compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress);
            originalFileStream.CopyTo(compressionStream);
        }
    }
}