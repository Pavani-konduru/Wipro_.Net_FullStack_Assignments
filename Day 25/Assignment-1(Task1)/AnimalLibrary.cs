using System;

namespace AnimalLibrary
{
    public interface IAnimal
    {
        void Speak();
    }
    public interface IMovable
    {
        void Move();
    }
    public class BaseClass
    {
        public string Description { get; }
        public BaseClass(string description)
        {
            Description = description;
        }
    }
    public class AnimalHandler : BaseClass, IAnimal, IMovable
    {
        public AnimalHandler(string description) : base(description)
        {
        }
        public void Speak()
        {
            Console.WriteLine($"{Description}: Roar!");
        }
        public void Move()
        {
            Console.WriteLine($"{Description} is moving.");
        }
    }
}