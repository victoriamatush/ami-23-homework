from strategy import Strategy


class ReadFileStrategy(Strategy):

    def execute(self, lst, pos, filename):
        f = open(filename, 'r')
        f = f.read()
        f = f.split(" ")
        list2 = []
        for num in f:
            list2.append(int(num))

        for i in range(pos, pos + len(list2)):
            lst.insert(i, list2[i-pos])

        return lst

    def getName(self):
        return 'readfile'
