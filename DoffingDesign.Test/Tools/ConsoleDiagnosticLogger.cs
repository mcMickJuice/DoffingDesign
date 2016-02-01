using System;
using System.Diagnostics;
using DoffingDesign.Service;

namespace DoffingDesign.Test.Tools
{
    public class ConsoleDiagnosticLogger: IDiagnosticLogger
    {
        public void LogActivity(string message, TimeSpan timeElapsed)
        {
            Debug.WriteLine(message);
        }

        public void LogActivity(string message)
        {
            Debug.WriteLine(message);
        }

        public void LogError(string message)
        {
            Debug.WriteLine(string.Format("Error : {0}", message));
        }
    }
}