from collection import Collection
from goods import Goods


def main():
    arr = Collection()
    f = input("Enter the file name: ")
    arr.read_file(f)

    while True:

        choice = int(input("\n1.Show list\n2.Search sth\n3.Sort by attribute\n4.Delete an object\n"
                               "5.Add an object\n6.Update an object\n7.Write to file\n8.End testing\n"))

        if choice == 1:
            arr.print()

        if choice == 2:
            to_search = input("Enter what you want to search:")
            arr.locate(to_search)

        if choice == 3:
            print("Enter an attribute to sort by:\n1. id\n2. code\n3. "
                  "title\n4. type\n5. amount\n6. price\n7. data")
            value = input("Attribute:")
            arr.sort_by_attr(value)

        if choice == 4:
            print("\n")
            val1 = input("To delete an object enter an id: ")
            arr.remove_good(int(val1))

        if choice == 5:
            print("Input Data: ")
            input_dict = {"id": None, "code": None, "title": None, "type": None,
                          "amount": None, "price": None, "data": None}
            for k in input_dict.keys():
                input_dict[k] = input(f"Input {k}: ")
                if k in ["id", "amount"]:
                    input_dict[k] = int(input_dict[k])
                if k == "price":
                    input_dict[k] = float(input_dict[k])

            print("Output Data: ")
            for k, v in input_dict.items():
                print(f"{k} -> {v}")

            good = Goods(**input_dict)
            arr.add_good(good)

        if choice == 6:
            print("\n")
            val1 = input("Enter id of the object you want to update: ")
            arr.update_good(int(val1))

        if choice == 7:
            wf = input("Enter the file to write: ")
            arr.write_file(wf)

        if choice == 8:
            break


main()
