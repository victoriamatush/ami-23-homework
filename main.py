from context import Context
from IteratorStrategy import IteratorStrategy
from ReadFile import ReadFileStrategy
from validation import Validation


def menu():
    a = Context()
    while True:
        print("\n 1. Read file strategy"
              "\n 2. Iterator strategy"
              "\n 3. Generate a list"
              "\n 4. Delete element from the position"
              "\n 5. Delete some elements "
              "\n 6. Method to work "
              "\n 7. Print a list"
              "\n 8. Exit ")
        choice = int(input("\nMake your choice:"))

        if choice == 1:
            a.SetStrategy(ReadFileStrategy)
            print("Strategy set to readfile")
        elif choice == 2:
            a.SetStrategy(IteratorStrategy)
            print("Strategy set to iterator")
        elif choice == 3:
            generate(a)
        elif choice == 4:
            delete(a)
        elif choice == 5:
            deleteinrange(a)
        elif choice == 6:
            method(a)
        elif choice == 7:
            a.GetList().printlist()
        elif choice == 8:
            break


def generate(a):
    if a.GetStrategy() == 'readfile':
        pos = int(input("Enter position: "))
        filename = input("Enter filename: ")
        if len(a.GetList()) == 0:
            pos = 0

        if Validation.f_exists(filename) and Validation.f_is_empty(filename):
            a.executeStrategy(a.GetList(), pos, filename)

    elif a.GetStrategy() == 'iterator':
        pos = int(input("Enter position: "))
        k = int(input("Enter a minimal number: "))
        b = int(input("Enter a maximal number: "))
        n = int(input("Enter amount of numbers : "))

        if len(a.GetList()) == 0:
            pos = 0

        a.executeStrategy(a.GetList(), pos, k, b, n)


def delete(a):
    if Validation.validateContext(a):
        pos = int(input('Enter position: '))
        a.GetList().pop(pos)
        print('Item deleted!')


def deleteinrange(a):
    if Validation.validateContext(a):
        start = int(input('Enter start position: '))
        end = int(input('Enter end position: '))
        if start > end or end >= a.GetList().len():
            raise ValueError('Bad index value')

        for i in range(end - start + 1):
            a.GetList().pop(start)

        print('Items deleted')


def method(a):
     if Validation.validateContext(a):
        a.GetList().indexsort()


menu()

