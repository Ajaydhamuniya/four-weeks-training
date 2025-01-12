﻿using System;
class Circle
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }
    public double GetArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }

    public double GetCircumference()
    {
        return 2 * Math.PI * Radius;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Circle circle = new Circle(5);
        Console.WriteLine($"Circle with radius {circle.Radius}");
        Console.WriteLine($"Area: {circle.GetArea()}");
        Console.WriteLine($"Circumference: {circle.GetCircumference()}");
    }

}