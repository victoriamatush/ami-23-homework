def filling_matrix(n):
    matrix = [[0] * n for i in range(n)]
    p = 1
    for i in range(n):
        for j in range(n):
            if i == j:
                matrix[i][j] = p * (p + 1)
        p += 1
    return matrix


def main():
    while True:
        try:
            n = int(input("Enter the amount of rows and lines:"))
        except ValueError:
            print('Please enter a whole number')
        break

    print(filling_matrix(n))


main()
