using NLog;

namespace Framework.Logging
{
    public class CustomLogEventInfo : LogEventInfo
    {
        public byte[] Screenshot { get; set; }
    }
}
