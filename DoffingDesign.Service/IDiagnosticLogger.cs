using System;

namespace DoffingDesign.Service
{
    public interface IDiagnosticLogger
    {
        void LogActivity(string message, TimeSpan timeElapsed);
        void LogActivity(string message);
    }

    public class DiagnosticLogger: IDiagnosticLogger
    {
        public void LogActivity(string message, TimeSpan timeElapsed)
        {
            System.Diagnostics.Trace.TraceInformation("Message: {0}; Duration: %{1}%", message, timeElapsed.TotalMilliseconds);
        }

        public void LogActivity(string message)
        {
            System.Diagnostics.Trace.TraceInformation("Message: {0}", message);
        }
    }
}