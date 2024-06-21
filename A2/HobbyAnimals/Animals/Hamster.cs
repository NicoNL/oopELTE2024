namespace HobbyAnimals;

//Primary Constructor inherited from Animal class
public class Hamster(string name, int exhilaration, char type) : Animal(name, exhilaration, type)
{
    public override void changeEx(Mood mood)
    {
        switch (mood)
        {
            case Mood.joyful:
                increaseEx(2);
                break;
            case Mood.usual:
                decreaseEx(3);
                break;
            case Mood.blue:
                decreaseEx(5);
                break;
        }
    }
}
