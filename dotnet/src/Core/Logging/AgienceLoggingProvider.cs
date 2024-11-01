﻿using Agience.Core.Logging;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Agience.Core.Logging
{
    public class AgienceLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, AgienceLogger> _loggers = new();

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new AgienceLogger(name));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
