class Pair:
    def __init__(self, number, frequency):
        self.number =  number
        if frequency is None:
            self.frequency =  0
        else:    
            self.frequency = frequency
    def increaseFrequency(self):
        self.frequency += 1
    def decreaseFrequency(self):
        if self.frequency == 0: raise Exception("The frequency is already 0")
        self.frequency -= 1
    def getNumber(self):
        return self.number
    def getFrequency(self):
        return self.frequency
    
