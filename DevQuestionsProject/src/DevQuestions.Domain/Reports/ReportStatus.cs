namespace DevQuestions.Domain.Reports
{
    /// <summary>
    /// Статус открыт
    /// </summary>
    public enum ReportStatus
    {
        OPEN,
        /// <summary>
        /// Статус в работе
        /// </summary>
        IN_PROGRESS,
        /// <summary>
        /// Статус Решен
        /// </summary>
        RESOLVED,
        /// <summary>
        ///  Статус закрыт
        /// </summary>
        DISSMESED,
    }
}