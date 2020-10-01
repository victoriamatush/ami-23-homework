from random import randint


class Node:
    def __init__(self, data):
        self.data = data
        self.next = None

    def get_next(self):
        return self.next


class LinkedList:
    def __init__(self):
        self.head = None

    def insert_at_start(self, data):
        to_insert = Node(data)
        to_insert.next = self.head
        self.head = to_insert

    def insert(self, data):
        new_node = Node(data)
        if self.head is None:
            self.head = new_node
            return
        findlast = self.head
        while findlast.next is not None:
            findlast = findlast.next
        findlast.next = new_node

    def clear(self):
        temp = self.head
        if temp is None:
            print("\n Not possible to delete empty list")
        while temp:
            self.head = temp.get_next()
            temp = None
            temp = self.head

    def make_random_list(self):
        amount = int(input("Enter the number of nodes: "))
        minimal = int(input("Enter the minimal number: "))
        maximal = int(input("Enter the maximal number: "))
        for i in range(amount):
            self.insert(randint(minimal, maximal))

    def make_list(self):
        amount = int(input("Enter the number of nodes: "))
        if amount == 0:
            return
        for i in range(amount):
            value = int(input("Enter the value:"))
            self.insert(value)

    def get_count(self):
        if self.head is None:
            return 0;
        n = self.head
        count = 0;
        while n is not None:
            count = count + 1
            n = n.next
        return count

    def rotate(self, k):
        if k == 0:
            return

        current = self.head

        count = 1
        while (count < k and current is not None):
            current = current.next
            count += 1
        if current is None:
            return

        kthNode = current
        while (current.next is not None):
            current = current.next
        current.next = self.head
        self.head = kthNode.next
        kthNode.next = None

    def delete(self):
        if self.head is None:
            print("List is empty")
            return

        todelete = self.head
        while todelete.next.next is not None:
            todelete = todelete.next
        todelete.next = None

    def indexsort(self, n):
        result = LinkedList()
        current = self.head
        i = 0
        while current is not None:
            if i % 2 == 0:
                result.insert(current.data)
            i += 1
            current = current.next

        current = self.head
        i = 0
        while current is not None:
            if i % 2 == 1:
                result.insert(current.data)
            i += 1
            current = current.next

        return result

    def printlist(self):
        if self.head is None:
            print("List has no element")
            return
        else:
            toprint = self.head
            while toprint is not None:
                print(toprint.data, end=" ")
                toprint = toprint.next


def main():
    mylist = LinkedList()
    while True:
        try:
            choice = int(input("Random numbers - press 1, enter by yourself - press 2, want to end program - 3: "))
        except ValueError:
            print('Please enter a whole number')

        if choice == 1:
            mylist.make_random_list()
        if choice == 2:
            mylist.make_list()
        if choice == 3:
            break
        mylist.printlist()

        while True:
            try:
                print(" ")
                k = int(input("Enter the amount of numbers to shift: "))
            except ValueError:
                print('Please enter a whole number')
            break

        mylist.rotate(k)
        mylist.printlist()

        print(" ")
        print("Index sorting:")
        result = mylist.indexsort(mylist.get_count())
        result.printlist()
        print(" ")

        mylist.clear()
        result.clear()


main()
