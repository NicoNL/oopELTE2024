namespace HobbyAnimals;

//Primary Constructor inherited from Animal class
public class Cat(string name, int exhilaration, char type) : Animal(name, exhilaration, type)
{
    public override void changeEx(Mood mood)
    {
        switch (mood)
        {
            case Mood.joyful:
                increaseEx(3);
                break;
            case Mood.usual:
                increaseEx(3);
                break;
            case Mood.blue:
                decreaseEx(7);
                break;
        }
    }
}
