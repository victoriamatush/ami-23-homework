from iterator import Iterator
from generator import generator


def nsd(a, b):
    while a*b != 0:
        if a >= b:
            a = a % b
        else:
            b = b % a
    return a + b


def nskforpairs(arr):
    res = []
    print(arr)
    for j in list(arr):
        for k in list(arr):
            if j != k:
                nsk = j * k // nsd(j, k)
                if nsk not in res:
                    res.append(nsk)
                    print("[" + str(j) + ", " + str(k) + "]: " + str(nsk))


def main():

    while True:
        try:
            choice = int(input("Make a choice:\n1.Iterator\n2.Generator\n3.End testing"))
            n = int(input("Enter amount of numbers: "))
            a = int(input("Enter first number: "))
            b = int(input("Enter second number: "))
        except ValueError:
            print('Please enter a whole number')


        if choice == 1:
            array = Iterator(a, b, n)
            arr = []
            for i in array:
                arr.append(i)

            print("Найменше спільне кратне для кожної пари: ")
            nskforpairs(arr)

        if choice == 2:
            print("GENERATOR")
            res = []
            for number in generator(a, b):
                res.append(number)
                if len(res) == n:
                    break

            print("Найменше спільне кратне для кожної пари: ")
            nskforpairs(res)

        if choice == 3:
            break


main()
