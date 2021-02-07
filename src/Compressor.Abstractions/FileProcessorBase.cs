using System.IO;

namespace Compressor
{
    public abstract class FileProcessorBase
    {
        protected FileInfo InputFile { get; set; }
        
        protected FileInfo OutputFile { get; set; }
        
        public abstract void Run();
    }
}