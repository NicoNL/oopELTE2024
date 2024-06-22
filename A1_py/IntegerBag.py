class IntegerBag:
    def __init__(self, numbers):
        if type(numbers) is None:
            self.elements = []
        elif type(numers) !=  list: raise Exception("The given parameter is not a list")
        else:
            self.elements = numbers
    
    def Insert(self, element):
        if type(element) != int: raise Exception("The given paramenter is not an int")
        found = False
        for element in self.elements:
            if element.getNumber() == element:
                element.increaseFrequency();
                found = True
        if found:
            newPair = pair.Pair(element)
            self.elements.append(newPair)