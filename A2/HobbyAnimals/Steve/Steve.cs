using TextFile;

namespace HobbyAnimals;


public class Steve(Animal[] animals, Mood mood)
{
    private Mood mood = mood;
    private Animal[] animals = animals;
    private List<Animal> bestAnimals = new();

    //When assigning a new mood to Steve, we first check the current exhilaration of the animals to check if its possible 
    //to make Steves mood better or not, this process is checked in the Read() method with another method called improvableDay().
    //The method improvable Day works from the second day. Since the task description did not specify if the first day should be
    //taken into account or not, the first day is not improved.
    public void setMood(Mood mood)
    {
        this.mood = mood;
    }

    //This methods checks if all of the alive animals have an exhilartion bigger or equal than 5
    public bool improvableDay(){
        foreach (Animal animal in animals)
        {
            if(animal.getEx() < 5 && animal.getEx() > 0){
                return false;
            }
        }
        return true;
    }
    //This method basically is going to take care or not of certain animals according to the new mood of Steve
    public void takeCareOfAnimals()
    {
        foreach (Animal animal in animals)
        {
            try
            {
                animal.changeEx(mood);
            }
            //These exceptions are useful in case we would like to keep track of the dead animals or the ones who 
            //reached the maximum exhilaration, also the finally block is useful for printing the animals and checking how 
            //Steve's care affected them
            catch (Animal.DeadAnimalException)
            {
                //Console.WriteLine("- " + animal.getName() + " is dead");
            }
            catch (Animal.LimitexhilarationException)
            {
                //Console.WriteLine("- " + animal.getName() + " has reached the maximum exhilariton ");
            }
            finally{
                //Console.WriteLine(" -Animal: " + animal.getType() + " " + animal.getName() + " exhilaration: "+ animal.getEx());

            }
        }
    }
    //Basic Maximum search algorithm for searching the animals with the Bigggest exhilaration and appending them to 
    //bestAnimals<Animal>
    public List<Animal> biggestEx()
    {
        //BestAnimals is empty for making the first element of animals the MAX, and for the sake of the documentation
        bestAnimals.Clear();
        Animal maxAnimal = animals[0];
        int max = maxAnimal.getEx();
        bestAnimals.Add(maxAnimal);
        for (int i = 1; i < animals.Length; i++)
        {
            if (animals[i].getEx() > max)
            {
                bestAnimals.Clear();
                max = animals[i].getEx();
                maxAnimal = animals[i];
                bestAnimals.Add(maxAnimal);
            }
            else if(animals[i].getEx() == max){
                bestAnimals.Add(animals[i]);
            }
        }
        return bestAnimals;
    }
}
