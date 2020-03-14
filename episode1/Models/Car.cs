using System;
using System.Collections.Generic;
using System.Text;

namespace episode1.Models
{
    public abstract class Car
    {
        public double Speed { get; protected set; } = 100;
        public double Acceleration { get; protected set; } = 10;
        public void Start()
        {
            Console.WriteLine("Turning on the engine");
            Console.WriteLine($"Running at: {Speed} km/h");
        }
        public void Stop()
        {
            Console.WriteLine("Stopping the car...");
        }
        public virtual void Accelerate()
        {
            Console.WriteLine("Accelerating...");
            Speed += Acceleration;
            Console.WriteLine($"Running at: {Speed} km/h");
        }
        public abstract void Boost();

    }
    public class Truck : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a truck...");
            base.Accelerate();

        }
        public override void Boost()
        {
            Console.WriteLine("Boosting a truck...");
            Speed += 50;
            Console.WriteLine($"Running the truck at: {Speed} km/h");
        }
    }
    public class SportCar : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a sportcar...");
            base.Accelerate();

        }
        public override void Boost()
        {
            Console.WriteLine("Boosting a sportcar...");
            Speed += 100;
            Console.WriteLine($"Running the sportcar at: {Speed} km/h");
        }
        public void DisplayInfo()
        {
            Console.WriteLine("Sportcar");
        }
    }
    public class Race
    {
        public void Begin()
        {
            Car sportCar = new SportCar();
            Car truck = new Truck();
            List<Car> cars = new List<Car>
            {
                sportCar, truck
            };
            foreach (Car car in cars)
            {
                car.Start();
                car.Accelerate();
                car.Boost();
            }
        }
        public void Casting()
        {
            Car sportCar = new SportCar();
            Car truck = new Truck();
            bool isSportCar = sportCar is SportCar;
            if (isSportCar)
            {
                ((SportCar)sportCar).DisplayInfo();
            }
            //SportCar realSportCar = (SportCar)sportCar;
            //realSportCar.DisplayInfo();


        }
    }
}
