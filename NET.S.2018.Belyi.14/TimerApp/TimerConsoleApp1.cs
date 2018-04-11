using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer;

namespace TimerApp
{
    class TimerConsoleApp1
    {
        static void Main(string[] args)
        {            
            Timer.Timer timer = new Timer.Timer(2);
            Console.WriteLine($"Новый таймер! {timer.GetType()}");
            Console.WriteLine("Время таймера:" + timer.Time);
            listener listener1 = new listener();
            timer.timerElapsed += listener1.MethodToInvoke;
            Console.WriteLine("Отсчёт пошёл!");
            timer.Start();

            Timer.Timer_ver2 timer2 = new Timer_ver2(5);
            Console.WriteLine($"\nНовый таймер! {timer2.GetType()}");
            Console.WriteLine("Время таймера:" + timer2.Time);
            timer2.timerTick += listener1.MethodToInvoke;
            timer2.timerElapsed += listener1.MethodToInvoke;
            Console.WriteLine("Отсчёт пошёл!");
            timer2.Start();            

        }

        public class listener
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="listener"/> class.
            /// </summary>
            public listener()
            {

            }

            /// <summary>
            /// Method to invoke.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The e.</param>
            public void MethodToInvoke(object sender, TimerElapsedEvenArgs e)
            {
                Console.WriteLine("Отсчёт закончен!");
                Console.WriteLine($"({nameof(MethodToInvoke)}) вызван {sender.GetType()}!!!! ");
            }

            /// <summary>
            /// Method to invoke.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The e.</param>
            public void MethodToInvoke(object sender, TimerTickEvenArgs e)
            {
                Console.WriteLine($"{e.Report} {(sender as Timer_ver2).Time}");
            }
        }
    }
}
