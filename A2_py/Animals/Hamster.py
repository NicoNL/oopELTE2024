class Hamster(Animal):
    def __init__(self, name: str, ex: int, type:str):
        self.name = name
        self.ex = ex
        self.type = type
    def changeEx(self, mood : Mood):
        match mood:
            case Mood.JOYFUL:
                self._increaseEx(2)
            case Mood.USUAL:
                self._decreaseEx(3)
            case Mood.BLUE:
                self._decreaseEX(5)
