import pair

class ElementNotInBagException(Exception):
    "The given Element is not in bag"
    
class EmptyBag(Exception):
    "The bag does not contain any elements"

class ElementNotInBagException(Exception):
    "The given Element is not in bag"
class IntegerBag:

    def __init__(self, numbers=None):
        if numbers is None:
            self.__elements = []
        elif not isinstance(numbers, list):
            raise ElementNotInBagException
        else:
            self.__elements = numbers

    def Insert(self, element):
        found = False
        for e in self.__elements:
            if e.getNumber() == element:
                e.increaseFrequency();
                found = True
        if not found:
            newPair = pair.Pair(element)
            self.__elements.append(newPair)
    
    def Remove(self, element):
        if not self.__Includes(element): raise ElementNotInBagException
        for e in self.__elements:
            if e.getNumber() == element:
                e.decreaseFrequency()
            if e.getFrequency() == 0:
                self.__elements.remove(e)

    def GetFrequency(self, element):
        if not self.__Includes(element): raise ElementNotInBagException
        for e in self.__elements:
            if e.getNumber() == element:
                return e.getFrequency()

    def GetMax(self):
        if self.Length() == 0: raise EmptyBag
        maxF = 0
        maxL = []
        for e in self.__elements:
            if maxF == e.getFrequency():
                maxL.append(e.getNumber())
            if maxF < e.getFrequency():
                maxL.clear()
                maxL.append(e.getNumber())
                maxF = e.getFrequency()
        return maxL, maxF
        
    def __Includes(self,element):
        for e in self.__elements:
            if e.getNumber() == element:
                return True
        return False

    def __str__(self):
        elems_str = [str(e) for e in self.__elements]
        return "[" + ",".join(elems_str) + "]"    

    def Length(self):
        return len(self.__elements)
