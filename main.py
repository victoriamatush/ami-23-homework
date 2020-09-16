a = int(input("Enter a number >=1 and <=109: "))
for i in range(a+1):
    if(i**i % a == 0 ):
        print(i)
        break