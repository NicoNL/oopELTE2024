class Pair:

    def __init__(self, number, frequency=None):
        self.number =  number
        if frequency is None:
            self.frequency =  1
        else:    
            self.frequency = frequency

    def increaseFrequency(self):
        self.frequency += 1

    def decreaseFrequency(self):
        if self.frequency == 0: raise Exception("Zero Frequency")
        self.frequency -= 1

    def getNumber(self):
        return self.number

    def getFrequency(self):
        return self.frequency

    def __str__(self):
        return f"({self.number}, {self.frequency})"
    
