using System;

namespace AnimalLibrary
{
    public class Lion
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }

        private string habitat;
        private bool isEndangered;
        private int weight;
        private int height;

        public Lion(string name, int age, string species, string habitat, bool isEndangered, int weight, int height)
        {
            Name = name;
            Age = age;
            Species = species;
            this.habitat = habitat;
            this.isEndangered = isEndangered;
            this.weight = weight;
            this.height = height;
        }

        public void ShowAnimalDetails()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Species: {Species}");
        }

        public void ShowHabitatDetails()
        {
            Console.WriteLine($"Habitat: {habitat}");
        }

        public void ShowHealthStatus()
        {
            Console.WriteLine($"Weight: {weight}, Height: {height}, Endangered: {isEndangered}");
        }

        public void UpdateHealthStatus(int newWeight, int newHeight)
        {
            weight = newWeight;
            height = newHeight;
            Console.WriteLine($"Health status updated: Weight = {weight}, Height = {height}");
        }

        public void Promote(string newPosition)
        {
            Console.WriteLine($"Employee is promoted as {newPosition}");
        }

        public void Work()
        {
            Console.WriteLine("Lion is working.");
        }
    }
}