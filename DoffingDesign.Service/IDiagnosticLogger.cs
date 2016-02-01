using System;

namespace DoffingDesign.Service
{
    public interface IDiagnosticLogger
    {
        void LogActivity(string message, TimeSpan timeElapsed);
        void LogActivity(string message);
        void LogError(string message);
    }
}