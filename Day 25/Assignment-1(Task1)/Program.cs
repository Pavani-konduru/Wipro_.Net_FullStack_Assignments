using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Console.WriteLine($"Exploring assembly: {assembly.GetName().Name}");
        Type[] types = assembly.GetTypes();
        foreach (Type type in types)
        {
            Console.WriteLine($"Type: {type.Name}");

            Console.WriteLine($"Base Type: {type.BaseType?.Name ?? "Object"}");

            Type[] interfaces = type.GetInterfaces();
            if (interfaces.Length > 0)
            {
                Console.Write("Interfaces: ");
                foreach (Type iface in interfaces)
                {
                    Console.WriteLine($"{iface.Name} ");

                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Interfaces: None ");
            }

            Console.WriteLine(); 
        }

    }
}