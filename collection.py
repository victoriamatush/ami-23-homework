import json
import os
import pathlib
from goods import Goods
from validation import Validation
import re

class Collection:

    def __init__(self):
        self.arr = []

    def read_file(self, filename=""):
        import pathlib
        db_file = pathlib.Path(filename)
        if not db_file.exists():
            print("- - -File is ot exist- - -")
            return

        goods = json.loads(db_file.read_text())
        if not goods:
            print("- - -File is empty- - -")

        for good in goods:
            is_valid = all([
                Validation.is_digital(good["id"]),
                Validation.valid_title(good["title"]),
                Validation.valid_code(good["code"]),
                Validation.is_digital(good["amount"]),
                Validation.valid_type(good["type"]),
                Validation.valid_price(good["price"]),
                Validation.valid_data(good["data"])
            ])
            if is_valid:
                self.arr.append(Goods(**good))

    def write_file(self, filename=""):
        target_data = []

        for good in self.arr:
            target_data.append(good.to_dict())
        with open(filename, 'w') as fp:
            fp.write(
                '[' +
                ',\n'.join(json.dumps(i) for i in target_data) +
                ']\n')

    def print(self):
        for g in self.arr:
            g.output()
            print("-- -- -- -- -- -- --")

    def add_good(self, good: Goods):
        array = [item for item in self.arr if item.id == good.id]
        if len(array) > 0:
            print('Object with this id already exist!')
            self.update_good(good=good)
        else:
            self.arr.append(good)

    def update_good(self, id_value=None, good=None):

        if id_value:
            for good in self.arr:
                if good.__getattribute__("id") == id_value:
                    id_value = input("Enter new id: ")

            for good in self.arr:
                if good.__getattribute__("id") == id_value:
                    good.id = int(input("Enter new id:"))
                    good.code = input("Enter new code:")
                    good.title = input("Enter new title:")
                    good.type = input("Enter new type:")
                    good.amount = int(input("Enter new amount:"))
                    good.price = float(input("Enter new price:"))
                    good.data = input("Enter new data:")
        else:
            for present_good in self.arr:
                if good.id == present_good.id:
                    self.arr.remove(present_good)
                    self.arr.append(good)

    def remove_good(self, id_value):
        for good in self.arr:
            if good.__getattribute__("id") == id_value:
                self.arr.remove(good)

    def sort_by_attr(self, attribute):
        self.arr.sort(key=lambda x: x.__getattribute__(attribute))

    def locate(self, pattern=""):
        occurences = []
        for good in self.arr:
            array = good.attr_arr()
            for i in array:
                result = re.findall(str(pattern), str(i), re.IGNORECASE)
                if result:
                    if good not in occurences:
                        occurences.append(good)
                        good.output()
