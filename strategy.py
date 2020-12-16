from abc import abstractmethod


class Strategy:
    def __init__(self):
        pass

    @abstractmethod
    def getName(self):
        pass

    @abstractmethod
    def execute(self, *args):
        pass
