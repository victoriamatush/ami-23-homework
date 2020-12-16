from LinkedList import LinkedList


class Context:

    def __init__(self):
        self.lst = LinkedList()
        self.strategy = None

    def SetStrategy(self, s):
        self.strategy = s

    def GetStrategy(self):
        return self.strategy.getName(self) if self.strategy else None

    def GetList(self):
        return self.lst

    def SetList(self, llist):
        self.lst = llist

    def executeStrategy(self, *args):
        if self.strategy is not None:
            self.lst = self.strategy.execute(self, *args)
