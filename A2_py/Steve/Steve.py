class Steve:
    def __init__(self,animals : list[Animal], Mood : mood):
        self.__animals =  animals
        self.__mood = mood
        self.__bestAnimals = []
    def setMood(self, Mood: mood):
        self.__mood = mood
    def improvableDay(self):
        for animal in self.__animals:
            if animal.getEx < 5 and animal.getEx > 0:
                return False
        return True
    def takeCareOfAnimals(self):
        for animal in self.__animals:
            try:
                animal.changeEx(self.__mood)
            except Animal.DeadAnimalException as e:
                pass
            except Animal.LimitExhilarationException as es:
                pass
            finally:
                pass
    def biggestEx(self):
        self.__bestAnimals = []
        maxAnimal = self.__animals[0]
        max =  maxAnimal.getEx()
        self.__bestAnimals.append(maxAnimal)
        for i in range (1, len(self.__animals)):
            if animals[i].getEx() > max:
                self.__bestAnimals = []
                max =  animals[i].getEx()
                maxAnimal = animals[i]
                self.__bestAnimals.add(maxAnimal)
            elif animals[i].getEx() == max:
                self.__bestAnimals.append(animals[i])
        return self.__bestAnimals




