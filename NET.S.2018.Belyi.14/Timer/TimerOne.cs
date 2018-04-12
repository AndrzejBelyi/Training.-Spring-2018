using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{  
    public sealed class TimerOne
    {     
        /// <summary>
        /// Initializes a new instance of the <see cref="TimerOne"/> class.
        /// </summary>
        public TimerOne()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerOne"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        public TimerOne(uint time)
        {
            Time = time;
        }

        /// <summary>
        /// Occurs when [timer elapsed].
        /// </summary>
        public event EventHandler<TimerElapsedEvenArgs> TimerElapsed = delegate { };

        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public uint Time { get; private set; } = 10;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            Thread.Sleep(TimeSpan.FromSeconds(Time));
            OnElapsed(this, new TimerElapsedEvenArgs());
        }

        /// <summary>
        /// Called when [elapsed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void OnElapsed(object sender, TimerElapsedEvenArgs eventArgs)
        {
            TimerElapsed?.Invoke(this, eventArgs);
        }        
    }
}
