from random import randint


class Node:
    def __init__(self, data):
        self.data = data
        self.next = None

    def get_next(self):
        return self.next


class LinkedList:
    def __init__(self):
        self.length = 0
        self.head = None

    def len(self):
        return self.length

    def insert(self, key, data):
        if key == 0:
            newNode = Node(data)
            temp = self.head
            self.head = newNode
            newNode.next = temp
            self.length += 1
            return

        if key == self.length:
            self.append(data)
            return

        currentNode, i = self.head, 0
        prevNode = None
        while currentNode is not None:
            if i == key:
                newNode = Node(data)
                prevNode.next = newNode
                newNode.next = currentNode
                self.length += 1
                return
            prevNode = currentNode
            currentNode = currentNode.next
            i += 1

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

    def pop(self, key=0):
        if (key == 0):
            temp = self.head
            self.head = self.head.next if self.head else None
            self.length -= 1
            return

        currentNode, i = self.head, 0
        prevNode = None
        while currentNode is not None:
            if (i == key):
                prevNode.next = currentNode.next
                currentNode.next = None
                self.length -= 1
                return
            prevNode = currentNode
            currentNode = currentNode.next
            i += 1

    def add(self, data):
        new_node = Node(data)
        if self.head is None:
            self.head = new_node
            return
        findlast = self.head
        while findlast.next is not None:
            findlast = findlast.next
        findlast.next = new_node

    def indexsort(self):
        result = LinkedList()
        current = self.head
        i = 0
        while current is not None:
            if i % 2 == 0:
                result.add(current.data)
            i += 1
            current = current.next

        current = self.head
        i = 0
        while current is not None:
            if i % 2 == 1:
                result.add(current.data)
            i += 1
            current = current.next

        result.printlist()

    def printlist(self):
        if self.head is None:
            print("List has no element")
            return
        else:
            toprint = self.head
            while toprint is not None:
                print(toprint.data, end=" ")
                toprint = toprint.next

    def append(self, data):
        if self.head is None:
            self.head = Node(data)
        else:
            currentNode = self.head
            while currentNode.next is not None:
                currentNode = currentNode.next
            currentNode.next = Node(data)
        self.length += 1
