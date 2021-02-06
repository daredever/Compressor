using CommandLine;

namespace Compressor.Tool
{
    [Verb("compress", HelpText = "Compress file.")]
    internal sealed class CompressOptions : Options
    {
    }

    [Verb("decompress", HelpText = "Decompress file.")]
    internal sealed class DecompressOptions : Options
    {
    }

    internal class Options
    {
        [Value(0, MetaName = "input file", HelpText = "Input file to be processed.", Required = true)]
        public string InputFile { get; set; }

        [Value(1, MetaName = "output file", HelpText = "Output file to be processed.", Required = true)]
        public string OutputFile { get; set; }
    }
}