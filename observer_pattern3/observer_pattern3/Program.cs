using System;
using System.Collections.Generic;

public interface ISubject
{
    void RegisterObserver(IObserver observer, string @event);
    void RemoveObserver(IObserver observer, string @event);
    void NotifyObservers(string @event);
}

public interface IObserver
{
    void Update(float temperature, float humidity, float pressure);
}

public class WeatherStation : ISubject
{
    private Dictionary<string, List<IObserver>> observers;
    private float temperature;
    private float humidity;
    private float pressure;

    public WeatherStation()
    {
        observers = new Dictionary<string, List<IObserver>>();
    }

    public void RegisterObserver(IObserver observer, string @event)
    {
        if (!observers.ContainsKey(@event))
        {
            observers[@event] = new List<IObserver>();
        }
        observers[@event].Add(observer);
    }

    public void RemoveObserver(IObserver observer, string @event)
    {
        if (observers.ContainsKey(@event))
        {
            observers[@event].Remove(observer);
            if (observers[@event].Count == 0)
            {
                observers.Remove(@event);
            }
        }
    }

    public void NotifyObservers(string @event)
    {
        if (observers.ContainsKey(@event))
        {
            foreach (var observer in observers[@event])
            {
                observer.Update(temperature, humidity, pressure);
            }
        }
    }

    public void SetMeasurements(string @event, float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        NotifyObservers(@event);
    }
}

public class Display : IObserver
{
    public void Update(float temperature, float humidity, float pressure)
    {
        Console.WriteLine($"Display: Temperature = {temperature}°C, Humidity = {humidity}%, Pressure = {pressure}Pa");
    }
}

class Program
{
    static void Main(string[] args)
    {
        WeatherStation weatherStation = new WeatherStation();

        // Create displays
        Display display1 = new Display();
        Display display2 = new Display();
        Display display3 = new Display();

        // Register displays as observers for different events
        weatherStation.RegisterObserver(display1, "event1");
        weatherStation.RegisterObserver(display3, "event1");
        weatherStation.RegisterObserver(display2, "event2");

        // Set some initial measurements for event1
        weatherStation.SetMeasurements("event1", 25.5f, 60.0f, 1013.0f);

        // Change weather for event2
        //weatherStation.SetMeasurements("event2", 28.0f, 55.0f, 1012.0f);

        // Remove one display from event2
        //weatherStation.RemoveObserver(display2, "event2");

        // Change weather again for event2
        //weatherStation.SetMeasurements("event2", 30.0f, 50.0f, 1010.0f);

        Console.ReadLine();
    }
}
