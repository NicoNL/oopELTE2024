class Tarantula(Animal):
    def __init__(self, name: str, ex: int, type:str):
        self.name = name
        self.ex = ex
        self.type = type
    def changeEx(self, mood : Mood):
        match maood:
            case Mood.JOYFUL:
                self._increaseEx(1)
            case Mood.USUAL:
                self._decreaseEx(2)
            case Mood.BLUE:
                self._decreaseEX(3)
