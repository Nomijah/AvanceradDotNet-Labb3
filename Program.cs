using System.Diagnostics;

namespace AvanceradDotNet_Labb3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Thread c1 = new Thread(runCar1);
            //Thread c2 = new Thread(runCar2);

            //c1.Start();
            //c2.Start();

            Run();
        }

        public async static void Run()
        {
            List<Car> cars = new List<Car>();
            Car c1 = new Car("Bugatti");
            Car c2 = new Car("Koenigsegg");
            Car c3 = new Car("Ferrari");
            cars.Add(c1);
            cars.Add(c2);
            cars.Add(c3);
            Thread c1Drive = new Thread(() => c1.Drive(c1));
            Thread c2Drive = new Thread(() => c2.Drive(c2));
            Thread c3Drive = new Thread(() => c3.Drive(c3));
            c1Drive.Start();
            c2Drive.Start();
            c3Drive.Start();


            while (!c1.Finished && !c2.Finished && !c3.Finished)
            {
                Console.Clear();

                foreach (Car car in cars)
                {
                    if (car.Name.Length > 7)
                    {
                        Console.WriteLine($"Bil : {car.Name} \t Distans : {Math.Round(car.DistanceTravelled, 2)} m \t Hastighet : {car.Speed} km/h");
                    }
                    else
                    {
                        Console.WriteLine($"Bil : {car.Name} \t\t Distans : {Math.Round(car.DistanceTravelled, 2)} m \t Hastighet : {car.Speed} km/h");
                    }
                }
                Console.WriteLine();
                foreach (Car car in cars)
                {
                    if (car.carProblem != 0)
                    {
                        switch (car.carProblem)
                        {
                            case 1:
                                Console.WriteLine($"Åh nej! {car.Name} har slut på bensin " +
                                    $"och måste tanka.");

                                break;
                            case 2:
                                Console.WriteLine($"Åh nej! {car.Name} har fått punka och " +
                                    $"måste stanna för att byta däck.");

                                break;
                            case 3:
                                Console.WriteLine($"Åh nej! {car.Name} har fått en fågel " +
                                    $"på vindrutan och måste städa upp.");
                                break;
                        }
                    }
                    if (car.Stopwatch.IsRunning)
                    {
                        Console.WriteLine($"Åh nej! {car.Name} har fått ett motorfel " +
                            $"som gör att hastigheten sänks med 1km/h");
                    }
                }
                Thread.Sleep(20);
            }
            Console.Clear();

            double longestDrive = 0;
            for (int i = 0; i < cars.Count; i++)
            {
                for (int j = 0; j < cars.Count; j++)
                {
                    if (i != j)
                    {
                        if (cars[i].DistanceTravelled > cars[j].DistanceTravelled)
                        {
                            Car temp = cars[i];
                            cars[i] = cars[j];
                            cars[j] = temp;
                        }
                    }
                }
            }

            for (int i = 0; i < cars.Count; i++)
            {
                cars[i].Placement = i + 1;
            }

            foreach (Car car in cars)
            {
                if (car.Placement == 1)
                {
                    Console.WriteLine($"Vinnaren är {car.Name}!!!! Körde {Math.Round(car.DistanceTravelled, 2)} meter.");
                }
                else if (car.Placement == 2)
                {
                    Console.WriteLine($"{car.Name} kom tvåa. Körde {Math.Round(car.DistanceTravelled,2)} meter.");
                }
                else if (car.Placement == 3)
                {
                    Console.WriteLine($"{car.Name} är sämst. Körde {Math.Round(car.DistanceTravelled,2)} meter.");
                }
            }

            Console.ReadKey();
        }
    }
}