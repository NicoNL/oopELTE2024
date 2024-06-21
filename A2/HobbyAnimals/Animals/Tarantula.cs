namespace HobbyAnimals;

//Primary Constructor inherited from Animal class
public class Tarantula(string name, int exhilaration, char type) : Animal(name, exhilaration, type)
{
    public override void changeEx(Mood mood)
    {
        switch (mood)
        {
            case Mood.joyful:
                increaseEx(1);
                break;
            case Mood.usual:
                decreaseEx(2);
                break;
            case Mood.blue:
                decreaseEx(3);
                break;
        }
    }
}
