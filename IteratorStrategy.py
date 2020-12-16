from strategy import Strategy
from Iterator import Iterator
from LinkedList import LinkedList


class IteratorStrategy(Strategy):
    def execute(self, lst: LinkedList, pos, a, b, n):
        arr= []
        for i in Iterator(a, b, n):
            arr.append(int(i))
        print(arr)
        for i in arr:
            lst.insert(pos, i)
            pos += 1

        return lst

    def getName(self):
        return 'iterator'
