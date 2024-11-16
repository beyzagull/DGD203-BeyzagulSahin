using System;

namespace Vehicles
{
    public class Car
    {
        public string Make { get; private set; }
        public string Model { get; private set; }
        public int MaxSpeed { get; private set; }
        public int CurrentSpeed { get; private set; }
        public double FuelCapacity { get; private set; }
        public double FuelLevel { get; private set; }
        public int Durability { get; private set; }
        public int Damage { get; private set; }
        public bool IsRunning { get; private set; }

        public Car(string make, string model, int maxSpeed, double fuelCapacity, int durability)
        {
            Make = make;
            Model = model;
            MaxSpeed = maxSpeed;
            FuelCapacity = fuelCapacity;
            FuelLevel = fuelCapacity;
            Durability = durability;
            Damage = 0;
            IsRunning = false;
        }

        public void Start()
        {
            if (FuelLevel > 0 && Damage < Durability)
            {
                IsRunning = true;
                Console.WriteLine($"{Make} {Model} started.");
            }
            else
            {
                Console.WriteLine($"{Make} {Model} cannot start. Check fuel and damage.");
            }
        }

        public void Stop()
        {
            IsRunning = false;
            CurrentSpeed = 0;
            Console.WriteLine($"{Make} {Model} stopped.");
        }

        public void Accelerate(int increment)
        {
            if (IsRunning)
            {
                if (FuelLevel <= 0)
                {
                    Console.WriteLine("Out of fuel!");
                    Stop();
                    return;
                }

                CurrentSpeed += increment;
                if (CurrentSpeed > MaxSpeed)
                    CurrentSpeed = MaxSpeed;

                FuelLevel -= 0.1 * increment; 
                Console.WriteLine($"Accelerated to {CurrentSpeed} km/h. Fuel level: {FuelLevel:F1}L.");
            }
            else
            {
                Console.WriteLine("Start the car first.");
            }
        }

        public void Brake(int decrement)
        {
            if (IsRunning)
            {
                CurrentSpeed = Math.Max(0, CurrentSpeed - decrement);
                Console.WriteLine($"Braked to {CurrentSpeed} km/h.");
            }
            else
            {
                Console.WriteLine("Car is not running.");
            }
        }

        public void TakeDamage(int amount)
        {
            Damage += amount;
            if (Damage >= Durability)
            {
                Damage = Durability;
                Console.WriteLine($"{Make} {Model} is totaled.");
                Stop();
            }
            else
            {
                Console.WriteLine($"{Make} {Model} took {amount} damage. Current damage: {Damage}/{Durability}.");
            }
        }

        public void Refuel(double amount)
        {
            FuelLevel = Math.Min(FuelCapacity, FuelLevel + amount);
            Console.WriteLine($"Refueled to {FuelLevel}L.");
        }

        public void Repair()
        {
            if (Damage > 0)
            {
                Damage = 0;
                Console.WriteLine($"{Make} {Model} has been repaired.");
            }
            else
            {
                Console.WriteLine("No repair needed.");
            }
        }
    }
}
