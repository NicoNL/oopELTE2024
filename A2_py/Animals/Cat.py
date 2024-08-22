class Cat(Animal):
    def __init__(self, name: str, ex: int, type:str):
        self.name = name
        self.ex = ex
        self.type = type
    def changeEx(self, mood : Mood):
        