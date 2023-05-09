using System;
using System.Collections.Generic;

abstract class Animal
{
    public string Name;
    public int Age;

    public abstract void MakeSound();
}

class Dog : Animal, IMovable
{
    public override void MakeSound()
    {
        Console.WriteLine("ho ho");
    }

    public void Move()
    {
        Console.WriteLine("walking on four legs");
    }
}

class Cat : Animal, IMovable
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }

    public void Move()
    {
        Console.WriteLine("Jumping and climbing");
    }
}

interface IMovable
{
    void Move();
}

class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();
        animals.Add(new Dog() { Name = "Buddy", Age = 4 });
        animals.Add(new Cat() { Name = "Whiskers", Age = 2 });

        foreach (Animal animal in animals)
        {
            Console.WriteLine($"{animal.Name} ({animal.GetType().Name}) is {animal.Age} years old:");
            animal.MakeSound();

            if (animal is IMovable)
            {
                Console.Write($"{animal.Name} is moving: ");
                ((IMovable)animal).Move();
            }

            Console.WriteLine();
        }

        Console.ReadLine();
    }
}
