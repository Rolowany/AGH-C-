
// Zad 1
/*
string str = new String("");

StreamWriter sw = new StreamWriter("napisy.txt", append:true);
List<string> strings = new List<string>(); 

while (str != "koniec!")
{
    str = Console.ReadLine();    
    strings.Add(str);

    sw.WriteLine(str);
}
sw.Close();

strings.Sort();

foreach (string s in strings)
{
    Console.WriteLine(s);
}
*/

// Zad 2
/*
string pattern = Console.ReadLine();

StreamReader sr = new StreamReader("wzorce.txt");
int counter = 0;

while (!sr.EndOfStream)
{
    string? str = sr.ReadLine();
    Console.WriteLine(str);
    if (str.Contains(pattern))
    {
        Console.WriteLine("W linii {0} na pozycji {1}", counter, str.IndexOf(pattern));
    }
    counter++;
}
sr.Close();
*/