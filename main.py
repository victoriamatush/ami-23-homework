from random import randint


def indexsort(s, p):
    result = list()
    for i in range(p):
        if i % 2 == 0:
            result.append(s[i])
    for i in range(p):
        if i % 2 == 1:
            result.append(s[i])
    return result


def motion(f, step):
    if step < 0:
        step = abs(step)
        for i in range(step):
            f.append(f.pop(0))
    else:
        for i in range(step):
            f.insert(0, f.pop())
    return f


def main():
    array = []
    while True:
        try:
            choice = int(input("Random numbers - press 1, enter by yourself - press 2, want to end program - 3: "))
            size = int(input("Enter amount of numbers: "))
            break
        except ValueError:
            print('Please enter a whole number')


    if choice == 1:
        while True:
            try:
                a = int(input("Enter low limit: "))
                b = int(input("Enter high limit: "))
                break
            except ValueError:
                print('Please enter a whole number')
        for i in range(int(size)):
            array.append(randint(a, b))
    if choice == 2:
        print("Enter the elements of the array:")
        for i in range(int(size)):
            array.append(int(input("Element " + str(i) + ": ")))


    print(array)

    array = indexsort(array, size)
    print("Array sorted by indexes: ")
    print(array)

    while True:
        try:
            k = int(input("Enter amount of positions to shift: "))
            break
        except ValueError:
            print('Please enter a whole number')

    motion(array, k)
    print(array)


main()

