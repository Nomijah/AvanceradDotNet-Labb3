using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDotNet_Labb3
{
    internal class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int carProblem { get; set; }
        public int Speed { get; set; }
        public double DistanceTravelled { get; set; }
        public bool Finished = false;
        public Stopwatch Stopwatch { get; set; }
        public int Placement { get; set; }

        static int idCounter = 1;
        public Car(string name)
        {
            Id = idCounter;
            Name = name;
            carProblem = 0;
            Speed = 120;
            DistanceTravelled = 0;
            idCounter++;
            Stopwatch = new Stopwatch();
        }

        public async void Drive(Car car, int raceDistance)
        {
            Stopwatch timer = new Stopwatch();
            Thread timerThread = new Thread(() => timer.Start());
            timerThread.Start();
            Random random = new Random();
            while (DistanceTravelled < raceDistance)
            {
                if (Stopwatch.Elapsed.TotalSeconds > 3)
                {
                    Stopwatch.Reset();
                }
                if (timer.Elapsed.TotalSeconds > random.Next(3, 7))
                {
                    carProblem = RandomEvent();
                    timer.Restart();
                    switch (carProblem)
                    {
                        case 1:
                            Thread.Sleep(10000);
                            car.carProblem = 0;
                            break;
                        case 2:
                            Thread.Sleep(7000);
                            car.carProblem = 0;
                            break;
                        case 3:
                            Thread.Sleep(4000);
                            car.carProblem = 0;
                            break;
                        case 4:
                            Stopwatch.Start();
                            car.Speed -= 1;
                            break;
                    }
                }
                Thread.Sleep(50);
                car.DistanceTravelled += car.Speed / 3.6 * 0.05;
            }
            Finished = true;
        }



        public static int RandomEvent()
        {
            Random rnd = new Random();
            int randomEvent = rnd.Next(1, 51);
            if (randomEvent == 1)
            {
                return 1;
            }
            else if (randomEvent == 2 || randomEvent == 3)
            {

                return 2;
            }
            else if (randomEvent > 3 && randomEvent < 9)
            {
                return 3;
            }
            else if (randomEvent >= 10 && randomEvent <= 20)
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }
    }
}
