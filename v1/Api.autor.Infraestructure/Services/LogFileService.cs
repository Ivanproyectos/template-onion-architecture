using Api.autor.Application.Interfaces.Services;

namespace Api.autor.Shared.Services
{
    public class LogFileService<T> : ILoggerService<T> where T : class
    {
        private readonly Serilog.ILogger _logger;
        public LogFileService(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        public void LogError(string message, Exception ex)
        {
            _logger.Error(message, ex);
        }

        public void LogInfo(string message)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string message)
        {
            throw new NotImplementedException();
        }
    }
}
