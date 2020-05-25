using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comun.Logging
{
    public class SyslogLoggerProvider : ILoggerProvider
    {
        private string _host;
        private int _port;
        private readonly Func<string, LogLevel, bool> _filter;
        public SyslogLoggerProvider(string host, int port, Func<string, LogLevel, bool> filter)
        {
            _host = host;
            _port = port;
            _filter = filter;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new SyslogLogger(categoryName, _host, _port, _filter);
        }
        public void Dispose()
        {
        }
    }
}
