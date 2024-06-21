using System.Security.Cryptography.X509Certificates;
using TextFile;

namespace HobbyAnimals;

//This class serves as a file reader and an Enumerator for obtaining the animal with
// the biggest exhilaration in each day, also it initializes Steve class and its attributes 
public class Reader
{
    public class FileFormatException : Exception { }

    private TextFileReader f;

    private enum Status { abnorm, norm }
    private Status st;
    private Mood dx;
    private Animal[] animals;
    private int arrLength;
    private string current;
    private bool end;
    private Steve steve;

    public string Current()
    {
        return current;
    }
    public Reader(string filename)
    {
        f = new(filename);
        st = f.ReadInt(out arrLength) ? Status.norm : Status.abnorm;
        animals = new Animal[arrLength];
        animals = readAnimals();
        st = f.ReadChar(out char c) ? Status.norm : Status.abnorm;
        switch (c)
        {
            case 'j':
                dx = Mood.joyful;
                steve = new(animals, Mood.joyful);
                break;
            case 'u':
                dx = Mood.usual;
                steve = new(animals, Mood.usual);
                break;
            case 'b':
                dx = Mood.blue;
                steve = new(animals, Mood.blue);
                break;
        }
    }
    //Method for defining the array of Animals
    private Animal[] readAnimals()
    {
        for (int i = 0; i < arrLength && st == Status.norm; i++)
        {
            animals[i] = readAnimal();
        }
        return animals;
    }

    public bool End()
    {
        return end;
    }
    //Read and initialize an animal from the file
    private Animal readAnimal()
    {
        end = st == Status.abnorm;
        char type = '0';
        string name = "NotDefine";
        int exhilaration = 0;
        if (!end)
        {
            st = f.ReadChar(out type) ? Status.norm : Status.abnorm;
            st = f.ReadString(out name) ? Status.norm : Status.abnorm;
            st = f.ReadInt(out exhilaration) ? Status.norm : Status.abnorm;
        }
        switch (type)
        {
            case 'T':
                Tarantula t = new(name, exhilaration, type);
                return t;
            case 'H':
                Hamster h = new(name, exhilaration, type);
                return h;
            case 'C':
                Cat c = new(name, exhilaration, type);
                return c;
            default:
                throw new FileFormatException();
        }
    }
    //Read the current mood from the file and improving it if it is necesary
    public void Read()
    {
        st = f.ReadChar(out char c) ? Status.norm : Status.abnorm;
        switch (c)
        {
            case 'j':
                dx = Mood.joyful;
                break;
            case 'u':
                dx = Mood.usual;
                if (steve.improvableDay()) { dx = Mood.joyful; }
                break;
            case 'b':
                dx = Mood.blue;
                if (steve.improvableDay()) { dx = Mood.usual; }
                break;
        }
        steve.setMood(dx);
    }
    public void First()
    {
        //Read was not added because for initializing Steve class we need to obtain the first mood from the file
        Next();

    }
    //Simple next method for reading the Moods from the file and returning the animals with the biggest exhilaration
    public void Next()
    {
        end = Status.abnorm == st;
        if (!end)
        {
            //Check the current mood from the file
            //Console.WriteLine("This is the mood read from the file: " + dx);
            steve.takeCareOfAnimals();

            if (steve.biggestEx().Count == 1)
            {
                current = steve.biggestEx()[0].ToString() + ".";
            }
            else
            {
                current = "";
                for (int i = 0; i < steve.biggestEx().Count; i++)
                {
                    if (i == steve.biggestEx().Count - 1)
                    {
                        current += steve.biggestEx()[i].ToString() + ".";
                    }
                    else
                    {
                        current += steve.biggestEx()[i].ToString() + ", ";
                    }
                }
            }
            Read();
        }
    }
}
