using System;
using System.Reflection;
using AnimalLibrary;

class Program
{
    static void Main()
    {
        InspectLionType();
        InvokeLionMethods();
    }

    static void InspectLionType()
    {
        Console.WriteLine("Task 2: Inspecting type Lion");

        Type lionType = typeof(Lion);

        object lionInstance = Activator.CreateInstance(lionType, "Simba", 4, "Panthera leo", "Savannah", true, 180, 120);

        Console.WriteLine("\nPublic Properties:");
        PropertyInfo[] properties = lionType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo property in properties)
        {
            object value = property.GetValue(lionInstance);
            Console.WriteLine($"- {property.Name} ({property.PropertyType.Name}) = {value}");
        }
        Console.WriteLine("\nPrivate Fields:");
        FieldInfo[] fields = lionType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (FieldInfo field in fields)
        {
            object value = field.GetValue(lionInstance);
            Console.WriteLine($"- {field.Name} ({field.FieldType.Name}) = {value}");
        }
    }

    static void InvokeLionMethods()
    {
        Console.WriteLine("\nTask 3: Invoking methods with and without parameters");

        Type lionType = typeof(Lion);

        object lionInstance = Activator.CreateInstance(lionType, "Simba", 4, "Panthera leo", "Savannah", true, 180, 120);

        MethodInfo[] methods = lionType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        foreach (MethodInfo method in methods)
        {
            Console.WriteLine($"\nMethod: {method.Name}");
            ParameterInfo[] parameters = method.GetParameters();
            Console.WriteLine($"No of Parameters: {parameters.Length}");

            if (method.Name == "ShowAnimalDetails")
            {
                Console.WriteLine("Calling ShowAnimalDetails method:");
                method.Invoke(lionInstance, null);
            }
            else if (method.Name == "ShowHabitatDetails")
            {
                Console.WriteLine("Calling ShowHabitatDetails method:");
                method.Invoke(lionInstance, null);
            }
            else if (method.Name == "ShowHealthStatus")
            {
                Console.WriteLine("Calling ShowHealthStatus method:");
                method.Invoke(lionInstance, null);
            }
            else if (method.Name == "UpdateHealthStatus")
            {
                Console.WriteLine("Calling UpdateHealthStatus method with parameters:");
                method.Invoke(lionInstance, new object[] { 200, 130 });
            }
            else if (method.Name == "Promote")
            {
                Console.WriteLine("Calling Promote method with parameters:");
                method.Invoke(lionInstance, new object[] { "Senior Developer" });
            }
            else if (method.Name == "Work")
            {
                Console.WriteLine("Calling Work method with no parameters:");
                method.Invoke(lionInstance, null);
            }
        }
    }
}