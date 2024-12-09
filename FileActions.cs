using System.Text.Json;

namespace Proiect;

public class FileActions
{
    private const string _directory = @"C:\work\UPT\POO dummy\temp";
    private const string _fileName = @"demo.json";
    private const string _fileNameState = @"state.json";
    
    public void WriteEntity(HelloClass entity)
    {
        if (!Directory.Exists(_directory))
        {
            Console.WriteLine("Creating directory: " + _directory);
            Directory.CreateDirectory(_directory);
        }
        
        var fileInfo = new FileInfo(Path.Combine(_directory, _fileName));
        
        var jsonContent = JsonSerializer.Serialize(entity);
        if (!File.Exists(fileInfo.FullName))
        {
            Console.WriteLine("Creating new file in: " + _directory);
            File.WriteAllText(fileInfo.FullName, jsonContent);
        }
        else
        {
            Console.WriteLine($"Append details to file: {fileInfo.Name}");
            File.AppendAllText(fileInfo.FullName, jsonContent);
        }
    }

    public void SaveState(State state)
    {
        if (!Directory.Exists(_directory))
        {
            Console.WriteLine("Creating directory: " + _directory);
            Directory.CreateDirectory(_directory);
        }
        
        var fileInfo = new FileInfo(Path.Combine(_directory, _fileNameState));
        
        var jsonContent = JsonSerializer.Serialize(state);
        if (File.Exists(fileInfo.FullName))
            File.Delete(fileInfo.FullName);
        
        Console.WriteLine($"rewrite state: {fileInfo.Name}");
        File.WriteAllText(fileInfo.FullName, jsonContent);
    }

    public State? ReadState()
    {
        if (!Directory.Exists(_directory))
        {
            Console.WriteLine("Creating directory: " + _directory);
            Directory.CreateDirectory(_directory);
        }
        
        var fileInfo = new FileInfo(Path.Combine(_directory, _fileNameState));

        if (!File.Exists(fileInfo.FullName))
        {
            Console.WriteLine($"Not able to read file: {fileInfo.Name}");
            return null;
        }

        try
        {
            var state = JsonSerializer.Deserialize<State>(File.ReadAllText(fileInfo.FullName));
            return state;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
}