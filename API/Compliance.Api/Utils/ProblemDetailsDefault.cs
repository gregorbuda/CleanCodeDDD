

namespace Compliance.Api.Utils
{
    /// <summary>
    /// Problem details for default response
    /// </summary>
    public class ProblemDetailsDefault
    {
        /// <summary>
        /// Indicates that the call response is inccorrect.
        /// </summary>
        /// <value>
        /// The code result.
        /// </value>
        /// <example>False</example>
        public bool Success { get; set; }
        /// <summary>
        /// The code result.
        /// </summary>
        /// <value>
        /// The code result.
        /// </value>
        /// <example>Default</example>
        public String CodeResult { get; set; }
        /// <summary>
        /// The message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        /// <example>Default</example>
        public String Message { get; set; }
        /// <summary>
        /// In this case it is always null, because there is no data to display.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public String Data { get; set; }
    }
}
