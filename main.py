from random import randint

def evklid(a, b):
    if a % b == 0:
        return b
    else:
        return evklid(b, a % b)

while True:
    try:
        N = int(input("Enter amount of numbers: "))
        a = int(input("Enter first number: "))
        b = int(input("Enter second number: "))
        break
    except ValueError:
        print('Please enter a whole number')

array = list()
results = list()

for i in range (int(N)):
    array.append(randint(int(a), int(b)))
print("Random numbers:" + str(array))

print("Найменше спільне кратне для кожної пари: ")
for i in array:
    for k in array:
        if i != k:
            evklid(i, k)
            nsk = i*k
            if nsk not in results:
                results.append(nsk);
                print("[" + str(i) + ", " + str(k) + "]: " + str(nsk))
