using System.Threading;
using System.Threading.Channels;
namespace ConsoleApp_Timer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minutesInput = 0;
            int secondsInput = 0;
            
            while (true)
            {
                Console.WriteLine("To start a timer, press enter. \nTo exit, enter \"1\".");

                if (Console.ReadLine() == "1")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                }

                bool success = false;
                while (!success)
                {
                    Console.WriteLine("How many minutes would you like the timer to run for?");
                    success = int.TryParse(Console.ReadLine(), out minutesInput);
                    if (!success) 
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                }
                
                success = false;

                while(!success)
                {
                   Console.WriteLine("How many additional seconds would you like the timer to run for?");
                   success = int.TryParse(Console.ReadLine(), out secondsInput);
                    if (!success)
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                }

                Countdown countdown1 = new Countdown(minutesInput, secondsInput);

                Console.WriteLine("Timer prepared for {0} minutes and {1} seconds, press enter to start the timer", countdown1.Length/60, countdown1.Length%60);
                Console.ReadLine();

                countdown1.StartTimer();

                Console.WriteLine("Press enter for actions");
                if (Console.ReadLine() != null)
                {
                    if (countdown1.IsTimerRunning == true)
                    {
                            countdown1.CancelTimer();
                    }

                    if (countdown1.IsAlarmRinging == true)
                    {
                            countdown1.StopAlarm();
                    }
                }
            }
        }
    }
}
