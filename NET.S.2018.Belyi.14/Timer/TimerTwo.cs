using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    public sealed class TimerTwo
    {       
        /// <summary>
        /// Initializes a new instance of the <see cref="TimerOne"/> class.
        /// </summary>
        public TimerTwo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerOne"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        public TimerTwo(uint time)
        {
            Time = time;
        }

        /// <summary>
        /// Occurs when [timer elapsed].
        /// </summary>
        public event EventHandler<TimerElapsedEvenArgs> TimerElapsed = delegate { };

        /// <summary>
        /// Occurs when [timer tick].
        /// </summary>
        public event EventHandler<TimerTickEvenArgs> TimerTick = delegate { };

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
            TimerTickEvenArgs tickArgs = new TimerTickEvenArgs("Тик...так");
            while (Time != 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Time--;
                OnTick(this, tickArgs);
            }

            OnElapsed(this, new TimerElapsedEvenArgs());
        }

        /// <summary>
        /// Called when [tick].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void OnTick(object sender, TimerTickEvenArgs eventArgs)
        {
            TimerTick?.Invoke(this, eventArgs);
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
