using WebAPISample.Interface;

namespace WebAPISample.Implementation;

public class PrintMessageImplementation : IPrintMessage
{
    private readonly ILogger<PrintMessageImplementation> _logger;

    public PrintMessageImplementation(ILogger<PrintMessageImplementation> logger)
    {   
        _logger = logger;
    }

    public string Print(string req){
        Console.WriteLine("routed here");
        return req;
    }
}