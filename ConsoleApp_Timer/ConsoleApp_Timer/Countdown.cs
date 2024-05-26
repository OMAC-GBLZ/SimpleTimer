using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Timer
{
    internal class Countdown
    {

        Timer timer;
        Timer alarm;

        public int Seconds { get; set; }
        public int Minutes { get; set; }
        public int Length;
        public bool IsAlarmRinging = false;
        public bool IsTimerRunning = false;

        public Countdown(int minutes, int seconds)
        {
            Minutes = minutes;
            Seconds = seconds;
            Length = minutes * 60 + seconds;
        }

        public void StartTimer()
        {
            Console.WriteLine("Timer has started");
            IsTimerRunning = true;
            timer = new Timer(TimerCallback, null, 0, 1000);
        }
        private void TimerCallback(object o)
        {

            if (Length > 0)
            {
                Console.Clear();
                Console.WriteLine($"{Length / 60} minutes {Length % 60}s remaining.\nPress enter at any time to cancel the timer.");
                Length--;
                GC.Collect();
            }
            else
            {
                Console.Clear();
                EndTimer();
            }
        }

        public void EndTimer()
        {
            IsTimerRunning = false;
            timer.Dispose();
            StartAlarm();
        }

        public void CancelTimer()
        {
            Console.Clear();
            Console.Beep();
            timer.Dispose();
            Console.WriteLine($"Timer cancelled with {Length / 60} minutes {Length % 60}s remaining");
        }

        public void StartAlarm()
        {
            IsAlarmRinging = true;
            alarm = new Timer(TimerCallback2, null, 0, 500);
            Console.WriteLine($"{Length / 60} minutes {Length % 60}s remaining.\nPress enter at any time to stop the alarm.");
        }

        private void TimerCallback2(object p)
        {
            Console.Beep();
            GC.Collect();
        }

        public void StopAlarm()
        {
            alarm.Dispose();
            Console.WriteLine("Alarm stopped");
            IsAlarmRinging = false;
        }
    }

    
}
