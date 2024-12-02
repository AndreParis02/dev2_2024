//I metodi di files

//Creare un file
string path = @"test.txt";
File.Create(path).Close();

//Scrivere su file
File.WriteAllText(path, "Hello, World!");

//Leggere da un file
string content = File.ReadAllText(path);
//stampo il contenuto del file
Console.WriteLine(content);

//Copiare un file
string path2 = @"test2.txt";
File.Copy(path, path2);

//Rinominare un file
string path3 = @"test3.txt";
File.Move(path2, path3);

//Eliminare il file
File.Delete(path3);

//Creare una directory
string dir = @"test";
Directory.CreateDirectory(dir);

//Eliminare una directory
Directory.Delete(dir);

//Creare un file temporaneo
string tempFile = Path.GetTempFileName();
Console.WriteLine(tempFile);

//Creare un file temporaneo in una directory specifica
//Path.Combine unisce i path in questo caso aggiunge "temp" alla directory temporanea
string tempDir= Path.Combine(Path.GetTempPath(),"temp");
Directory.CreateDirectory(tempDir);

// verificare se un file esiste (restituisce un valore booleano)
if (File.Exists(path))
{
    Console.WriteLine("File exists");
}

// verificare se una directory esiste
if (Directory.Exists(dir))
{
    Console.WriteLine("Directory exists");
}

// ottenere informazioni su un file
FileInfo info = new FileInfo(path);
Console.WriteLine(info.Length);
Console.WriteLine(info.CreationTime);

// fare riferimento solo al nome del file senza il path
string fileName = Path.GetFileName(path);
Console.WriteLine(fileName);

// fare riferimento solo all'estensione del file
string extension = Path.GetExtension(path);
Console.WriteLine(extension);

// fare riferimento solo al nome del file senza l'estensione
string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
Console.WriteLine(fileNameWithoutExtension);

// ottenere informazioni su una directory
DirectoryInfo dirInfo = new DirectoryInfo(dir);
Console.WriteLine(dirInfo.CreationTime);

// ottenere informazioni su tutti i file in una directory
string[] files = Directory.GetFiles(dir); // dir e il path della directory
                                          // se voglio partire dalla cartella del progetto di dotnet nel quale sono scrivo string dir = ".";
foreach (string file in files)
{
    Console.WriteLine(file);
}

// ottenere informazioni su tutte le directory in una directory
string[] dirs = Directory.GetDirectories(dir);
foreach (string d in dirs)
{
    Console.WriteLine(d);
}

// ottenere informazioni su tutti i file e le directory in una directory
string[] all = Directory.GetFileSystemEntries(dir);
foreach (string a in all)
{
    Console.WriteLine(a);
}

// ottenere informazioni su tutti i file e le directory in una directory con un filtro
string[] txtFiles = Directory.GetFiles(dir, "*.txt");
foreach (string txtFile in txtFiles)
{
    Console.WriteLine(txtFile);
}

// creare una copia di un file
string copyPath = Path.Combine(dir, "test.txt"); // Path.Combine unisce i path
File.Copy(path, copyPath);

// spostare un file
string movePath = Path.Combine(dir, "test2.txt");
File.Move(copyPath, movePath);

// eliminare un file
File.Delete(movePath);

// eliminare una directory e tutti i file e le directory al suo interno
Directory.Delete(dir, true);

// eliminare tutti i file in una directory
string[] files1 = Directory.GetFiles(dir);
foreach (string file in files1)
{
    File.Delete(file);
}

// eliminare tutti i file e le directory in una directory
string[] all1 = Directory.GetFileSystemEntries(dir);
foreach (string a in all1)
{
    if (File.Exists(a))
    {
        File.Delete(a);
    }
    else
    {
        Directory.Delete(a, true);
    }
}

// eliminare tutti i file e le directory in una directory con un filtro
string[] txtFiles1 = Directory.GetFiles(dir, "*.txt");
foreach (string txtFile in txtFiles1)
{
    File.Delete(txtFile);
}