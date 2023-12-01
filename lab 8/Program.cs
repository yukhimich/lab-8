using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
using System;
using System.Collections.Generic;

public sealed class ConfigurationManager
{
    private static ConfigurationManager _instance;
    private Dictionary<string, string> _config;

    private ConfigurationManager()
    {
        _config = new Dictionary<string, string>();
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ConfigurationManager();
            }
            return _instance;
        }
    }

    public void SetConfig(string key, string value)
    {
        _config[key] = value;
    }

    public string GetConfig(string key)
    {
        return _config.TryGetValue(key, out var value) ? value : null;
    }
}

class Program
{
    static void Main()
    {
        ConfigurationManager configManager = ConfigurationManager.Instance;

        Console.Write("Enter configuration key: ");
        string key = Console.ReadLine();

        Console.Write("Enter configuration value: ");
        string value = Console.ReadLine();

        configManager.SetConfig(key, value);

        ConfigurationManager anotherConfigManager = ConfigurationManager.Instance;
        Console.WriteLine($"Configuration value from another instance: {anotherConfigManager.GetConfig(key)}");
    }
}
using System;

// Абстрактний клас графіка
abstract class Graph
{
    public abstract void Draw();
}

// Конкретні класи графіка
class LineGraph : Graph
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Line Graph");
    }
}

class BarGraph : Graph
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Bar Graph");
    }
}

class PieChart : Graph
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Pie Chart");
    }
}

// Абстрактний клас фабрики
abstract class GraphFactory
{
    public abstract Graph CreateGraph();
}

// Конкретні класи фабрик
class LineGraphFactory : GraphFactory
{
    public override Graph CreateGraph()
    {
        return new LineGraph();
    }
}

class BarGraphFactory : GraphFactory
{
    public override Graph CreateGraph()
    {
        return new BarGraph();
    }
}

class PieChartFactory : GraphFactory
{
    public override Graph CreateGraph()
    {
        return new PieChart();
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter graph type (line/bar/pie): ");
        string graphType = Console.ReadLine();

        GraphFactory factory = null;

        switch (graphType.ToLower())
        {
            case "line":
                factory = new LineGraphFactory();
                break;
            case "bar":
                factory = new BarGraphFactory();
                break;
            case "pie":
                factory = new PieChartFactory();
                break;
            default:
                Console.WriteLine("Invalid graph type");
                return;
        }

        Graph graph = factory.CreateGraph();
        graph.Draw();
    }
}
using System;

// Абстрактні класи компонентів
abstract class Screen
{
    public abstract void Display();
}

abstract class Processor
{
    public abstract void Process();
}

abstract class Camera
{
    public abstract void Capture();
}

// Абстрактна фабрика
abstract class TechProductFactory
{
    public abstract Screen CreateScreen();
    public abstract Processor CreateProcessor();
    public abstract Camera CreateCamera();
}

// Конкретні класи компонентів
class SmartphoneScreen : Screen
{
    public override void Display()
    {
        Console.WriteLine("Smartphone Screen Displaying");
    }
}

class LaptopScreen : Screen
{
    public override void Display()
    {
        Console.WriteLine("Laptop Screen Displaying");
    }
}

class SmartphoneProcessor : Processor
{
    public override void Process()
    {
        Console.WriteLine("Smartphone Processor Processing");
    }
}

class LaptopProcessor : Processor
{
    public override void Process()
    {
        Console.WriteLine("Laptop Processor Processing");
    }
}

class SmartphoneCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Smartphone Camera Capturing");
    }
}

class LaptopCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Laptop Camera Capturing");
    }
}

// Конкретна фабрика
class SmartphoneFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new SmartphoneScreen();
    }

    public override Processor CreateProcessor()
    {
        return new SmartphoneProcessor();
    }

    public override Camera CreateCamera()
    {
        return new SmartphoneCamera();
    }
}

class LaptopFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new LaptopScreen();
    }

    public override Processor CreateProcessor()
    {
        return new LaptopProcessor();
    }

    public override Camera CreateCamera()
    {
        return new LaptopCamera();
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter product type (smartphone/laptop): ");
        string productType = Console.ReadLine();

        TechProductFactory factory = null;

        switch (productType.ToLower())
        {
            case "smartphone":
                factory = new SmartphoneFactory();
                break;
            case "laptop":
                factory = new LaptopFactory();
                break;
            default:
                Console.WriteLine("Invalid product type");
                return;
        }

        Screen screen = factory.CreateScreen();
        Processor processor = factory.CreateProcessor();
        Camera camera = factory.CreateCamera();

        screen.Display();
        processor.Process();
        camera.Capture();
    }
}
using System;

// Прототип для шаблонів даних
abstract class DataTemplate : ICloneable
{
    public abstract object Clone();
}

// Конкретні прототипи
class CSVTemplate : DataTemplate
{
    public string Data { get; set; }

    public override object Clone()
    {
        return new CSVTemplate { Data = this.Data };
    }
}

class XMLTemplate : DataTemplate
{
    public string Data { get; set; }

    public override object Clone()
    {
        return new XMLTemplate { Data = this.Data };
    }
}

class JSONTemplate : DataTemplate
{
    public string Data { get; set; }

    public override object Clone()
    {
        return new JSONTemplate { Data = this.Data };
    }
}

// Адаптер для забезпечення сумісності
class DataAdapter
{
    private DataTemplate _dataTemplate;

    public DataAdapter(DataTemplate dataTemplate)
    {
        _dataTemplate = dataTemplate;
    }

    public void ConvertToCSV()
    {
        // Логіка конвертації до CSV формату
        Console.WriteLine("Converting to CSV");
    }

    public void ConvertToXML()
    {
        // Логіка конвертації до XML формату
        Console.WriteLine("Converting to XML");
    }

    public void ConvertToJSON()
    {
        // Логіка конвертації до JSON формату
        Console.WriteLine("Converting to JSON");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter template type (csv/xml/json): ");
        string templateType = Console.ReadLine();

        DataTemplate template = null;

        switch (templateType.ToLower())
        {
            case "csv":
                template = new CSVTemplate();
                break;
            case "xml":
                template = new XMLTemplate();
                break;
            case "json":
                template = new JSONTemplate();
                break;
            default:
                Console.WriteLine("Invalid template type");
                return;
        }

        Console.Write("Enter data: ");
        template.Data = Console.ReadLine();

        DataAdapter adapter = new DataAdapter(template);

        Console.Write("Enter target format (csv/xml/json): ");
        string targetFormat = Console.ReadLine();

        switch (targetFormat.ToLower())
        {
            case "csv":
                adapter.ConvertToCSV();
                break;
            case "xml":
                adapter.ConvertToXML();
                break;
            case "json":
                adapter.ConvertToJSON();
                break;
            default:
                Console.WriteLine("Invalid target format");
                break;
        }
    }
}

}
