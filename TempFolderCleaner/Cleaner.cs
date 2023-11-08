using System.IO;
using Humanizer;

public class TempClean
{
    public static void Main(string[] args)
    {
        string? tempPath1 = @"C:\Windows\Temp";
        string? tempPath2 = @"C:\Windows\Prefetch";

        string[] dirs = Directory.GetDirectories(tempPath1, "*", SearchOption.AllDirectories);
        var files1 = Directory.GetFiles(tempPath2, "*.*", SearchOption.AllDirectories);
        var files2 = Directory.GetFiles(tempPath1,"*.*",SearchOption.AllDirectories);
        
        foreach(var dir in dirs)
        {
            if(Directory.Exists(dir))
            {
                DirectoryInfo indo = new DirectoryInfo(dir);
                Console.WriteLine($"{Path.GetDirectoryName(dir)} : {indo.CreationTime}");
                indo.Delete(true);
            }
        }
        Console.WriteLine("Cleaning files");

        foreach( var file in files1)
        {
            var info = new FileInfo(file);
            var humanizedSize = info.Length.Bytes().Humanize();
            Console.WriteLine($"{Path.GetFileName(file)} : {humanizedSize} bytes");
            info.Delete();
        }

        foreach (var file in files2)
        {
            var info = new FileInfo(file);
             
            Console.WriteLine($"{Path.GetFileName(file)} : {info.Length} bytes ");
            try
            {
                info.Delete();
            }
            catch(System.IO.IOException ex)  
            {
                Console.WriteLine($"Exception has occured here are the details \n{ex}");
            }
        }
        Console.WriteLine("All Temp files and folders are cleaned");

    }
}