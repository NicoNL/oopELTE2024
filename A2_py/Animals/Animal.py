class Animal(ABC):
    class DeadAnimalException(Exception):
        pass
    class LimitExhilarationException(Exception):
        pass

    def __init__(self, name : str, ex: int, type: str):
        self.name = name
        self.ex =  ex
        self.type = type

    def changeEx(self):
        pass
    def getName(self):
        return self.name
    def getEx(self):
        return self.ex
    def getType(self):
        return self.type
    def _decreaseEX(self, x):
        if self.ex == 0:
            raise Animal.DeadAnimalException(f"{self.type}:{self.name} has died")
        if self.ex  - x < 0:
            self.ex = 0
        else:
            self.ex -= x
    def _increaseEx(self,x):
        if self.ex == 70:
            raise Animal.LimitExhilarationException(f"{self.type}:{self.name} has died")
        if self.ex == 0:
            raise Animal.DeadAnimalException(f"{self.type}:{self.name} has died")
        if self.ex + x  > 70:
            self.ex = 70
        else:
            self.ex += x
    
    def __str(self):
        return f"{self.type}:{self.name}"
        