using System;
using Vehicles;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Car gameCar = new Car("Toyota", "Supra", 250, 60, 100);

            gameCar.Start();
            gameCar.Accelerate(30);
            gameCar.Accelerate(50);
            gameCar.Brake(20);
            gameCar.TakeDamage(20);
            gameCar.Accelerate(100);
            gameCar.TakeDamage(80);
            gameCar.Refuel(20);
            gameCar.Repair();
            gameCar.Start();
            gameCar.Accelerate(150);
            gameCar.Stop();
        }
    }
}
