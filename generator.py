from random import randint


def generator(a, b):
    while True:
        yield randint(int(a), int(b))