using HobbyAnimals;

namespace HobbyAnimalsTest;

[TestClass]
public class UnitTest
{
    [TestMethod]
    public void TestChangeEX()
    {
        Tarantula t = new ("spidy", 5, 'T');
        Cat c = new("kitty", 10, 'C');
        Hamster h = new("Alvin", 7, 'H');

        t.changeEx(Mood.joyful);
        c.changeEx(Mood.joyful);
        h.changeEx(Mood.joyful);
        //Exhilaration change when mood is Joyful   : Tarantula + 1 - Cat + 3 - Hamster + 2
        Assert.IsTrue(6 == t.getEx());
        Assert.IsTrue(13 == c.getEx());
        Assert.IsTrue(9 == h.getEx());

        t.changeEx(Mood.usual);
        c.changeEx(Mood.usual);
        h.changeEx(Mood.usual);
        //Exhilaration change when mood is usual  : Tarantula - 1 - Cat + 3 - Hamster - 2
        Assert.IsTrue(4 == t.getEx());
        Assert.IsTrue(16 == c.getEx());
        Assert.IsTrue(6 == h.getEx());

        t.changeEx(Mood.blue);
        c.changeEx(Mood.blue);
        h.changeEx(Mood.blue);
        //Exhilaration change when mood is blue : Tarantula - 3 - Cat - 7 - Hamster - 5
        Assert.IsTrue(1 == t.getEx());
        Assert.IsTrue(9 == c.getEx());
        Assert.IsTrue(1 == h.getEx());
    }
    [TestMethod]
    public void TestAnimalExceptions()
    {
        Tarantula t = new ("spidy", 1, 'T');
        Cat c = new("kitty", 1, 'C');
        Hamster h = new("Alvin", 1, 'H');

        t.changeEx(Mood.blue);
        c.changeEx(Mood.blue);
        h.changeEx(Mood.blue);
        //Animals are dead
        Assert.IsTrue(0 == t.getEx());
        Assert.IsTrue(0 == c.getEx());
        Assert.IsTrue(0 == h.getEx());
        //If we try to increment or decrement the exhilaration, we 
        //will encounter an exception
        try
        {
            t.changeEx(Mood.joyful);
            c.changeEx(Mood.usual);
            h.changeEx(Mood.blue);
            Assert.Fail("No Exception thrown");
        }
        catch(Exception e)
        {
            Assert.IsTrue(e is Animal.DeadAnimalException);
        }

        Cat c2 = new("Gatubela", 68, 'C');
        c2.changeEx(Mood.joyful);
        //The animal has reached the maximum exhilaration
        Assert.IsTrue(70 == c2.getEx());
        //If we try to increment the exhilaration, we 
        //will encounter an exception
        try
        {
            c2.changeEx(Mood.usual);
            Assert.Fail("No Exception thrown");
        }
        catch(Exception e)
        {
            Assert.IsTrue(e is Animal.LimitexhilarationException);
        }   
    }
    [TestMethod]
    public void TestImprovableDay()
    {
        Tarantula t = new ("spidy", 10, 'T');
        Cat c = new("kitty", 10, 'C');
        Hamster h = new("Alvin", 10, 'H');
        Tarantula t2 = new("Gwen", 0, 'T');

        Animal []animals = new Animal[4];
        animals[0] =  t;
        animals[1] =  c;
        animals[2] =  h;
        animals[3] =  t2;

        Steve s = new(animals, Mood.blue);
        //We are going to check if all the living animals' exhilaration is bigger than five
        Assert.IsTrue(s.improvableDay());
        animals[1].changeEx(Mood.blue);
        //Now kitty's exhilaration is less than five, now it should return false
        Assert.IsFalse(s.improvableDay());
    }
    [TestMethod]
    public void TestTakeCareOfAnimals()
    {
        Tarantula t = new ("spidy", 50, 'T');
        Cat c = new("kitty", 50, 'C');
        Hamster h = new("Alvin", 50, 'H');
        Tarantula t2 = new("Gwen", 1, 'T');

        Animal []animals = new Animal[4];
        animals[0] =  t;
        animals[1] =  c;
        animals[2] =  h;
        animals[3] =  t2;

        Steve s = new(animals, Mood.blue);
        //Since Steve's current mood is blue all of the animals' exhilartion should be decreased
        s.takeCareOfAnimals();
        Assert.IsTrue(47 == animals[0].getEx());
        Assert.IsTrue(43 == animals[1].getEx());
        Assert.IsTrue(45 == animals[2].getEx());
        Assert.IsTrue(0 == animals[3].getEx());
        //Now we're going to assing a new mood to Steve
        s.setMood(Mood.usual);
        //Now we're going to check if we can improve this mood by checking all living animals mood
        Assert.IsTrue(s.improvableDay());
        //Improving the mood is something the file Reader class is in charge of when is reading the mood from the file and it does that thanks to this method
        //So let's say that the mood has been improved
        s.setMood(Mood.joyful);
        s.takeCareOfAnimals();
        //now the exhilaration of all of the animals should be increased but the dead animals
        Assert.IsTrue(48 == animals[0].getEx());
        Assert.IsTrue(46 == animals[1].getEx());
        Assert.IsTrue(47 == animals[2].getEx());
        Assert.IsTrue(0 == animals[3].getEx());
    }
    [TestMethod]
    public void TestBiggestEx()
    {
        Tarantula t = new ("spidy", 51, 'T');
        Cat c = new("kitty", 50, 'C');
        Hamster h = new("Alvin", 50, 'H');
        Tarantula t2 = new("Gwen", 1, 'T');

        Animal []animals = new Animal[4];
        animals[0] =  t;
        animals[1] =  c;
        animals[2] =  h;
        animals[3] =  t2;

        Steve s = new(animals, Mood.blue);

        s.takeCareOfAnimals();
        Assert.IsTrue(48 == animals[0].getEx());
        Assert.IsTrue(43 == animals[1].getEx());
        Assert.IsTrue(45 == animals[2].getEx());
        Assert.IsTrue(0 == animals[3].getEx());

        //Now the only animal with the biggest exhilaration must be 'spidy'
        List<Animal> bestAnimals = s.biggestEx();
        //Check if there's just one animal
        Assert.IsTrue(bestAnimals.Count == 1);
        Assert.IsTrue(bestAnimals[0].getName() == "spidy");
        s.setMood(Mood.usual);
        s.takeCareOfAnimals();
        //Now the animals with the biggest exhilaration must be spidy and kitty
        Assert.IsTrue(46 == animals[0].getEx());
        Assert.IsTrue(46 == animals[1].getEx());
        Assert.IsTrue(42 == animals[2].getEx());
        Assert.IsTrue(0 == animals[3].getEx());
        //Check if there're two animals
        bestAnimals = s.biggestEx();
        Assert.IsTrue(bestAnimals.Count == 2);
        Assert.IsTrue(bestAnimals[0].getName() == "spidy");
        Assert.IsTrue(bestAnimals[1].getName() == "kitty");
    }
    //In this test we want to test how the program would work with the following data for 3 days
    [TestMethod]
    public void TestGeneral()
    {
        Tarantula t = new ("spidy", 51, 'T');
        Cat c = new("kitty", 50, 'C');
        Hamster h = new("Alvin", 50, 'H');
        Tarantula t2 = new("Gwen", 1, 'T');

        Animal []animals = new Animal[4];
        animals[0] =  t;
        animals[1] =  c;
        animals[2] =  h;
        animals[3] =  t2;

        Steve s = new(animals, Mood.blue);
        //The first day is not affected by the method improvableDay()
        s.takeCareOfAnimals();
        List<Animal> bestAnimals = s.biggestEx();
        Assert.IsTrue(bestAnimals.Count == 1);
        Assert.IsTrue(bestAnimals[0].getName() == "spidy");
        //Second day
        s.setMood(Mood.usual);
        Assert.IsTrue(s.improvableDay());
        s.setMood(Mood.joyful);
        s.takeCareOfAnimals();
        bestAnimals = s.biggestEx();
        Assert.IsTrue(bestAnimals.Count == 1);
        Assert.IsTrue(bestAnimals[0].getName() == "spidy");
        //Third day
        s.setMood(Mood.blue);
        Assert.IsTrue(s.improvableDay());
        s.setMood(Mood.usual);
        s.takeCareOfAnimals();
        bestAnimals = s.biggestEx();
        Assert.IsTrue(bestAnimals.Count == 1);
        Assert.IsTrue(bestAnimals[0].getName() == "kitty");
    }
}