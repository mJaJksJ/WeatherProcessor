namespace WeatherProcessor.Exceptions
{
    /// <summary>
    /// Класс Iris ошибок
    /// </summary>
    internal abstract class WeatherProcessorException : Exception
    {
        /// <summary>
        /// Сообщение ошибки (рус)
        /// </summary>
        public string RussianMessage { get; }

        /// <summary>
        /// .ctor
        /// </summary>
        protected WeatherProcessorException(string russianMessage = null) : base()
        {
            RussianMessage = russianMessage;
        }

        /// <inheritdoc/>
        public override string Message => $"WeatherProcessor process error:\n ({RussianMessage})";
    }
}
