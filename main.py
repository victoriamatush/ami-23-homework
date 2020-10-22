from Collection import Collection
from Employee import Employee


def main():
    arr = Collection()
    arr.read_file(filename='text.json')
    arr.print()

    print("Input new Employee: ")
    input_dict = {
        "name": None, "salary": None, "first_working_date": None, "last_working_date": None
    }
    for k in input_dict.keys():
        input_dict[k] = input(f"Input {k}: ")

    test1 = Employee(**input_dict)
    arr.add(test1)
    arr.print()

main()