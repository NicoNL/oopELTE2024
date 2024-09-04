class Steve:
    def __init__(self,animals : list[Animal], Mood : mood):
        self.__animals =  animals
        self.__mood = mood
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
        



