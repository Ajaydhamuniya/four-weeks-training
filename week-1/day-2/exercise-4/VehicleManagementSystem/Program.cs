using System;
using System.Collections.Generic;

interface IVehicle
{
    void Drive();
}


class Car : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Driving a car...");
    }
}


class Truck : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Driving a truck...");
    }
}

class VehicleLogger
{
    private static VehicleLogger instance;

    private VehicleLogger() { }

    public static VehicleLogger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new VehicleLogger();
            }
            return instance;
        }
    }

    public void Log(string message)
    {
        Console.WriteLine($"Logging: {message}");
    }
}


abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();
    public void DoSomethingWithVehicle()
    {
        // Do something with vehicle
    }
}

// Implement CarFactory
class CarFactory : VehicleFactory
{
    public override IVehicle CreateVehicle()
    {
        return new Car();
    }
}

// Implement TruckFactory
class TruckFactory : VehicleFactory
{
    public override IVehicle CreateVehicle()
    {
        return new Truck();
    }
}

// Implement Repository Pattern with IRepository<T> interface
interface IRepository<T>
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}

// Implement VehicleRepository that implements IRepository<IVehicle> interface
class VehicleRepository : IRepository<IVehicle>
{
    private List<IVehicle> vehicles = new List<IVehicle>();

    public IVehicle GetById(int id)
    {
        return vehicles[id];
    }

    public IEnumerable<IVehicle> GetAll()
    {
        return vehicles;
    }

    public void Add(IVehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void Update(IVehicle vehicle)
    {

    }

    public void Delete(IVehicle vehicle)
    {
        vehicles.Remove(vehicle);
    }
}

// Implement VehicleService that uses VehicleRepository and VehicleLogger
class VehicleService
{
    private readonly IRepository<IVehicle> repository;
    private readonly VehicleLogger logger;

    public VehicleService(IRepository<IVehicle> repository)
    {
        this.repository = repository;
        logger = VehicleLogger.Instance;
    }

    public void AddVehicle(VehicleFactory factory)
    {
        IVehicle vehicle = factory.CreateVehicle();
        repository.Add(vehicle);
        logger.Log("Vehicle added");
    }

    public void RemoveVehicle(int id)
    {
        IVehicle vehicle = repository.GetById(id);
        repository.Delete(vehicle);
        logger.Log("Vehicle removed");
    }

    public void ListVehicles()
    {
        foreach (IVehicle vehicle in repository.GetAll())
        {
            Console.WriteLine(vehicle.GetType().Name);
        }
    }

    public void DoSomethingWithVehicle(int id)
    {
        IVehicle vehicle = repository.GetById(id);
        vehicle.Drive();

    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create VehicleService instance
        VehicleRepository repository = new VehicleRepository();
        VehicleService service = new VehicleService(repository);

        // Create Car and Truck factories
        VehicleFactory carFactory = new CarFactory();
        VehicleFactory truckFactory = new TruckFactory();

        // Add vehicles using VehicleService
        service.AddVehicle(carFactory);
        service.AddVehicle(truckFactory);

        service.ListVehicles();

        service.DoSomethingWithVehicle(0);
        service.RemoveVehicle(1);
        service.ListVehicles();
    }
}