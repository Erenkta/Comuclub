namespace Comuclub.Common
{
    public interface ILog
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message);  
    }
    public class Logger : ILog
    {
        private readonly ILogger _logger;
        public void LogError(string message)
        {
            _logger.LogError(message);
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }
    }
}
