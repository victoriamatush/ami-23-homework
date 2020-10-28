from random import randint


class Iterator:
    def __init__(self, a, b, n):
        self.counter = 0
        self.a = a
        self.b = b
        self.n = n
        self.element = 0

    def __iter__(self):
        return self

    def __next__(self):
        while self.counter < self.n:
            self.element = randint(int(self.a), int(self.b))
            self.counter += 1
            return self.element
        if self.counter >= self.n:
            raise StopIteration
