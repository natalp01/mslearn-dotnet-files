using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);   

var salesFiles = FindFiles(storesDirectory);
var salesTotal = CalculateSalesTotal(salesFiles);

File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;
    
    // Loop over each file path in salesFiles
    foreach (var file in salesFiles)
    {      
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);
    
        // Parse the contents as JSON
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);
    
        // Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;
    }
    
    return salesTotal;
}

record SalesData (double Total);



// var currentDirectory = Directory.GetCurrentDirectory();
// var storesDirectory = Path.Combine(currentDirectory,"stores");
// var salesTotalDir = Path.Combine(currentDirectory,"salesTotalDir");
// Directory.CreateDirectory(salesTotalDir);
// File.WriteAllText(Path.Combine(salesTotalDir,"totals.txt"),string.Empty);

// //var salesFiles = FindFiles("stores");
// //foreach (var file in salesFiles)
// //{
//   //  Console.WriteLine(file);
// //}

// // See https://aka.ms/new-console-template for more information
// //Console.WriteLine("Hello, World!");
// IEnumerable<string> FindFiles(string folderName)
// {
//     List<string> salesFiles = new List<string>();
    
//     var foundFiles = Directory.EnumerateFiles(folderName,"*",SearchOption.AllDirectories);
//     foreach (var file in foundFiles)
//     {
//         var extension = Path.GetExtension(file);
//         //if (file.EndsWith("sales.json"))
//         if (extension ==".json")
//         {
//             salesFiles.Add(file);
//         }
//     }
//     return salesFiles;
// }
// //var salesFiles = FindFiles("stores");
// //var salesFiles = FindFiles(storesDirectory);
// //foreach (var file in salesFiles)
// //{
// //    Console.WriteLine(file);
// //    Console.WriteLine(Path.GetExtension(file));
// //}


// double CalculateSalesTotal(IEnumerable<string> salesFiles)
// {
//     double salesTotal = 0;
    
//     // Loop over each file path in salesFiles
//     foreach (var file in salesFiles)
//     {      
//         // Read the contents of the file
//         string salesJson = File.ReadAllText(file);
    
//         // Parse the contents as JSON
//         SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);
    
//         // Add the amount found in the Total field to the salesTotal variable
//         salesTotal += data?.Total ?? 0;
//     }
    
//     return salesTotal;
// }

// record SalesData (double Total);







// IEnumerable<string> listOfDirectories = Directory.EnumerateDirectories("stores", "201", SearchOption.AllDirectories);
// foreach(var dir in listOfDirectories)
// {
//     Console.WriteLine(dir);
    
// }


// var salesJson = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
// var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);
// Console.WriteLine(salesData.Total);
// var data = JsonConvert.DeserializeObject<SalesTotal>(salesJson);
// File.WriteAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt",data.Total.ToString());
// File.AppendAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", $"{data.Total}{Environment.NewLine}");
// class SalesTotal
// {
//     public double Total { get ; set ; }
// }
// Console.WriteLine(Directory.GetCurrentDirectory());
// string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
// Console.WriteLine(docPath);
// Console.WriteLine($"stores{Path.DirectorySeparatorChar}201");
// Console.WriteLine(Path.Combine("stores","201"));
// Console.WriteLine(Path.GetExtension("sales.json"));
// string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";

// FileInfo info = new FileInfo(fileName);

// Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}");

// Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "stores","201","newDir"));

// bool doesDirectoryExist = Directory.Exists(storesDirectory);
// Console.WriteLine(doesDirectoryExist);

// File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Hello World!");
// File.WriteAllText(Path.Combine(storesDirectory, "newfile.txt"), "New file");
