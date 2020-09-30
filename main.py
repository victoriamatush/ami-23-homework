from random import randint


def nsd(a, b):
    while a*b != 0:
        if a >= b:
            a = a % b
        else:
            b = b % a
    return a + b


def nskforpairs(arr):
    res = list()

    for j in arr:
        for k in arr:
            if j != k:
                nsk = j * k // nsd(j, k)
                if nsk not in res:
                    res.append(nsk)
                    print("[" + str(j) + ", " + str(k) + "]: " + str(nsk))


def main():
    array = list()

    while True:
        try:
            n = int(input("Enter amount of numbers: "))
            a = int(input("Enter first number: "))
            b = int(input("Enter second number: "))
            break
        except ValueError:
            print('Please enter a whole number')

    for p in range(int(n)):
        array.append(randint(int(a), int(b)))
    print("Random numbers:" + str(array))

    print("Найменше спільне кратне для кожної пари: ")
    nskforpairs(array)


main()
