using System.Text;

string path = "";
if(args.Length>0)
    path = args[0];
else
{
    Console.WriteLine("Enter the path of a directory.");
    path = Console.ReadLine();
}

Console.OutputEncoding = Encoding.UTF8;


if (!Directory.Exists(path))
{
    Console.WriteLine($"Directory {path} does not exist");
    return;
}
Console.WriteLine("-------------------------------------------------------------------------");
Console.WriteLine();
ScanDir(path,1);


void ScanDir(string dir, int level)
{
   if (level==1) 
    Console.WriteLine(" ".PadLeft((level-1)*3)+ dir);
   else
    Console.WriteLine("---".PadLeft((level - 1) * 3) + Path.GetFileName(dir)+"--");
 // Подкаталоги
    string[] subDirs = Directory.GetDirectories(dir+@"\", "*", SearchOption.TopDirectoryOnly);
    foreach (string subDir in subDirs)    
        ScanDir(subDir, level+1);
    
    //Файлы
    string[] files = Directory.GetFiles(dir + @"\", "*", SearchOption.TopDirectoryOnly);
    foreach (string f in files)    
        Console.WriteLine(" ".PadLeft((level - 1) * 3 + 1) + Path.GetFileName(f));

}
