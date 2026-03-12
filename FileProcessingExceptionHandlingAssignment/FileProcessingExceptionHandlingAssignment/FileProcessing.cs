using System.Linq;
using System.Text;

public class FileProcessing
{

    public string InputFilePath { get; private set; }

    public string OutputFilePath { get; private set; }
    public double AverageVal { get; private set; } 
    public double MinVal { get; private set; } 
    public double MaxVal { get; private set; } 

    

    public FileProcessing(string inputFilePath, string outputFilePath)
    {
        InputFilePath = inputFilePath;
        OutputFilePath = outputFilePath;
    }
    private string ReadFile(string inputFilePath)
    {
        string fileContent="";
        try
        {
            fileContent = File.ReadAllText(inputFilePath);
        }
        catch (FileNotFoundException ex)
        {
            throw new FileProcessingException("File not found");
        }

        return fileContent;
    }

    private List<double> FormatTheContent()
    {
        string fetchedFileContent = ReadFile(InputFilePath);

        string[] fileContentArray = fetchedFileContent.Split(',');

       List<double> valuesOfContent = fileContentArray
                              .Where(c => double.TryParse(c, out double temp))
                              .Select(c => double.Parse(c))
                              .ToList();
        return valuesOfContent;
    }

    List<double> fetchedValuesOfContent;
    private void Calculate()
    {
        fetchedValuesOfContent = FormatTheContent();
        this.AverageVal = fetchedValuesOfContent.Average();
        this.MinVal = fetchedValuesOfContent.Min();
        this.MaxVal = fetchedValuesOfContent.Max();
    }

    public void WriteProcessedDataInOutputFile()
    {
        Calculate();
        StringBuilder outputContent = new StringBuilder();
        outputContent.AppendLine($"Average : {AverageVal} \nMin Value : {MinVal} \nMax Value : {MaxVal}");
        File.WriteAllText( OutputFilePath, outputContent.ToString() );
    }
    

}

class FileProcessingException : Exception
{
    public FileProcessingException() { }

    public FileProcessingException(string message) : base(message) { }

    public FileProcessingException(string message,  Exception innerException) : base(message, innerException) { }

}