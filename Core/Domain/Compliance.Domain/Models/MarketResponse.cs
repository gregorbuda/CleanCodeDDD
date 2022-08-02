using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    /// <summary>
    /// Market Response
    /// </summary>
    public class MarketResponse
    {
        /// <summary>
        /// Market Id
        /// </summary>
        /// <value>
        /// Market Id
        /// </value>
        /// <example>1</example>
        public Int32 MarketId { get; set; }
        /// <summary>
        /// Market Name
        /// </summary>
        /// <value>
        /// MarketName
        /// </value>
        /// <example>Martket Test</example>
        public string MarketName { get; set; } = String.Empty;
        /// <summary>
        /// Market Description
        /// </summary>
        /// <value>
        /// Market Description
        /// </value>
        /// <example>Test Description</example>
        public string MarketDescription { get; set; } = String.Empty;
        /// <summary>
        /// Market Currency
        /// </summary>
        /// <value>
        /// Market Currency
        /// </value>
        /// <example>Dollar</example>
        public string MarketCurrency { get; set; } = String.Empty;
        /// <summary>
        /// Currency Symbol
        /// </summary>
        /// <value>
        /// Currency Symbol
        /// </value>
        /// <example>$</example>
        public string CurrencySymbol { get; set; } = String.Empty;
    }
}
