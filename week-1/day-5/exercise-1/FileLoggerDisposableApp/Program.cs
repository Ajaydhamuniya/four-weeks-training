namespace FileLoggerDisposableApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Use FileLogger and dispose of it properly
            FileLogger fl = new FileLogger("ajay.txt");
            fl.Log("My name is Ajay\n");
            fl.Log("I am 22 years old\n");
            fl.Dispose();
        }
    }

    class FileLogger : IDisposable
    {
        private StreamWriter _writer;

        public FileLogger(string filePath)
        {
            // Initialize StreamWriter instance
            _writer = new StreamWriter(filePath);
        }

        public void Dispose()
        {
            // Implement IDisposable pattern
            _writer.Dispose();
        }

        public void Log(string message)
        {
            // Write message to the file
            _writer.Write(message);
        }
    }
}