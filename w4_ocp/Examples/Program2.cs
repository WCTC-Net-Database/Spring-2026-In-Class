using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w4_ocp.Examples
{
    public class Program2
    {
        public static void Main2()
        {
            IAnimal dog = new Dog();
            dog.MakeSound();
            IAnimal cat = new Cat();
            cat.MakeSound();
            IAnimal pig = new Pig();
            pig.MakeSound();

            List<IAnimal> animals = new List<IAnimal> { dog, cat, pig };
            // compiler error : Cannot create an instance of the abstract class or interface 'IAnimal'
            //IAnimal animal = new IAnimal();

            CommuterCar car = new CommuterCar();
            car.Make = "Honda"; 
            car.StartEngine();

            ICar car1 = new CommuterCar();
            car1.Make = "Toyota";
            car1.StartEngine();

            ICar toyota = new CommuterCar
            {
                Make = "Toyota",
                Model = "Corolla",
                Year = 2020
            };
            toyota.StartEngine();

            ICar hybrid = new HybridCar
            {
                Make = "Toyota",
                Model = "Prius",
                Year = 2022
            };
            hybrid.StartEngine();

            ICar muscleCar = new MuscleCar
            {
                Make = "Dodge",
                Model = "Challenger",
                Year = 2021
            };
            muscleCar.StartEngine();

            Console.WriteLine("Cars in the system");

        }
    }

    public interface ICar 
    { 
        string Make { get; set; }
        string Model { get; set; }
        int Year { get; set; }

        void StartEngine();
        void StopEngine();
    }

    internal class CommuterCar : ICar
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public void StartEngine()
        {
            Console.WriteLine("Engine started.");
        }
        public void StopEngine()
        {
            Console.WriteLine("Engine stopped.");
        }
    }
    internal class MuscleCar : ICar 
    {         
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int HorsePower { get; set; }
        public void StartEngine()
        {
            Console.WriteLine("Engine started.");
        }
        public void StopEngine()
        {
            Console.WriteLine("Engine stopped.");
        }
    }
    internal class HybridCar : ICar
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string BatteryType { get; set; }

        public void PressStartButton()
        {
            Console.WriteLine("Engine button pressed.");
        }

        public void StartEngine()
        {
            Console.WriteLine("Engine started.");
        }

        public void StopEngine()
        {
            Console.WriteLine("Engine stopped.");
        }
    }
}
