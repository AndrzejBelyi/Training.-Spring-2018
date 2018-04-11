using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{  
    public sealed class Timer
    {
        /// <summary>
        /// Occurs when [timer elapsed].
        /// </summary>
        public event EventHandler<TimerElapsedEvenArgs> timerElapsed = delegate { };

        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public uint Time { get; private set; } = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="Timer"/> class.
        /// </summary>
        public Timer()
        {
          
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Timer"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        public Timer(uint time)
        {
            Time = time;
        }

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
            timerElapsed?.Invoke(this, eventArgs);
        }        
    }
}
