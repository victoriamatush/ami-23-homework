from random import randint
import math
N = input("Enter amount of numbers: ")
array = list()
a = input("Enter first number: ")
b = input("Enter second number: ")
for i in range (int(N)):
    array.append(randint(int(a),int(b)))
print("" + str(array))

results = list()

print ("Найменше спільне кратне для кожної пари: ")
for i in array:
    for k in array:
        if i!=k:
            def func(i, k):
                if i % k == 0 :
                    return k
                else:
                    return func(k, i % k)

            nsk = i*k
            if nsk not in results:
                results.append(nsk);
                print("[" + str(i) + ", " + str(k) + "]: " + str(nsk))
