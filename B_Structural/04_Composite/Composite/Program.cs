using Composite;

Console.Title = "Composite";

var root = new Composite.Directory("root", 0);

var firstLevelFile1 = new Composite.File("file1.txt", 100);
var firstLevelDirectory1 = new Composite.Directory("directory1", 4);
var firstLevelDirectory2 = new Composite.Directory("directory2", 8);
root.Add(firstLevelFile1);
root.Add(firstLevelDirectory1);
root.Add(firstLevelDirectory2);

var secondLevelFile1 = new Composite.File("file2.cs", 200);
var secondLevelFile2 = new Composite.File("file3.py", 150);
firstLevelDirectory2.Add(secondLevelFile1);
firstLevelDirectory2.Add(secondLevelFile2);

Console.WriteLine($"Size of first level directory 1 is {firstLevelDirectory1.GetSize()}.");
Console.WriteLine($"Size of first level directory 2 is {firstLevelDirectory2.GetSize()}.");
Console.WriteLine($"Size root is {root.GetSize()}.");
Console.WriteLine($"Size of second level file 2 is {secondLevelFile2.GetSize()}.");