using System;

namespace BridgeKata
{
    public class FileFormatException : Exception
    {
        public FileFormatException(string message) : base(message)
        {}
    }
}