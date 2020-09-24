def function(k):
    for i in range(k + 1):
        if (i ** i % k == 0):
            print(i)
            break


while True:
    try:
        a = int(input("Enter a number >=1 and <=109: "))
        break
    except ValueError:
        print('Please enter a whole number')

function(a)
