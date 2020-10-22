import json
import pathlib
from Employee import Employee
from Validation import Validation


class Collection:

    def __init__(self):
        self.arr = []

    def add(self, empl: Employee):
        self.arr.append(empl)
        Validation.valid_name(empl.name)
        Validation.valid_salary(empl.salary)
        self.write_file("text.json")

    def read_file(self, filename=""):
        with open(filename, 'r') as json_file:
            empl = json.loads(json_file.read())
            for atr in empl:
                self.arr.append(Employee(**atr))

    def print(self):
        for g in self.arr:
            g.output()
        print("-- -- -- -- -- -- --")

    def write_file(self, filename=""):
        target = pathlib.Path(filename)
        target_data = []

        for empl in self.arr:
            target_data.append(empl.to_dict())
        with open('text.json', 'w') as fp:
            fp.write(
                '[' +
                ',\n'.join(json.dumps(i) for i in target_data) +
                ']\n')
