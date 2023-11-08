public class Sorter
{
    public static void Main(string[] args)
    {
        string? rootPath = @"C:\Users\SURYANSH\Documents";
        string? destDir = Path.Combine(rootPath, "Docus");
        string? newPath = Path.Combine(destDir, "Text Files");

        //string[] dirs = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

        var txtFiles = Directory.GetFiles(destDir, "*.txt", SearchOption.AllDirectories);
        //var pdfFiles = Directory.GetFiles(rootPath, "*.pdf", SearchOption.AllDirectories);


        foreach(var txtFile in txtFiles)
        {
            Console.WriteLine(Path.GetFileName(txtFile));
        }
        
        bool directoryExists = Directory.Exists(destDir);

        if (directoryExists == false)
        {
            Console.WriteLine("Directory doesnt exist for Text Files");
            Directory.CreateDirectory(newPath);
        }
        else
        {
            foreach(var txtFile in txtFiles)
            {
                string dFilePath = Path.Combine(destDir, Path.GetFileName(txtFile));
                File.Move(txtFile, dFilePath);
                Console.WriteLine($"Moved {txtFile} to {dFilePath}");
            }
        }

        foreach (string dir in txtFiles)
        {
            string dFilePath = Path.Combine(newPath, Path.GetFileName(dir));
            File.Move(dir, dFilePath);
            Console.WriteLine($"Moved {dir} to {dFilePath}");
        }
        Sorter.DeleteRoutine(newPath);
    }
    public static void DeleteRoutine(string root)
    {
        string[] txt = Directory.GetFiles(root, "*.txt", SearchOption.AllDirectories);

        foreach(string txtFile in txt)
        {
            FileInfo f = new FileInfo(txtFile);
            
            if(f.Length > 10 * 1024 * 1024 ) 
            {
                File.Delete(txtFile);
                Console.WriteLine($"Deleted {txtFile} {f.Length} bytes");
            }
            Console.WriteLine("Check you Recycle Bin for Deleted files");
        }
    }
}