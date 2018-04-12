using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public sealed class TimerTickEvenArgs : EventArgs
    {
        /// <summary>
        /// Gets the report.
        /// </summary>
        /// <value>
        /// The report.
        /// </value>
        public string Report { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerTickEvenArgs"/> class.
        /// </summary>
        public TimerTickEvenArgs()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerTickEvenArgs"/> class.
        /// </summary>
        /// <param name="report">The report.</param>
        public TimerTickEvenArgs(string report)
        {
            Report = report;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public sealed class TimerElapsedEvenArgs : EventArgs
    {
        /// <summary>
        /// Gets the report.
        /// </summary>
        /// <value>
        /// The report.
        /// </value>
        public string Report { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerElapsedEvenArgs"/> class.
        /// </summary>
        public TimerElapsedEvenArgs()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerElapsedEvenArgs"/> class.
        /// </summary>
        /// <param name="report">The report.</param>
        public TimerElapsedEvenArgs(string report)
        {
            Report = report;
        }
    }
}
