public class Program
{

    public static void Main()
    {
        FileProcessing file = new FileProcessing(@"C:\Dummy\input.txt", @"C:\Dummy\output.txt");
        //file.GetProcessedData();
        file.WriteProcessedDataInOutputFile();
    }

}