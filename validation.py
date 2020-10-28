import re


class Validation:

    @staticmethod
    def is_digital(num):
        if num == int(num):
            return True
        else:
            print('- - -Invalid type of id or amount- - -')
            return False

    @staticmethod
    def valid_code(code):
        if re.match(r'[0-9]{3}[-][0-9]{3}[-][0-9]{3}', code):
            return True
        else:
            print("- - -Invalid type of code- - -")
            return False

    @staticmethod
    def valid_title(title):
        if re.fullmatch(r'[a-zA-z]+', title, re.IGNORECASE):
            return True
        else:
            print("- - -Invalid type of title- - -")
            return False

    @staticmethod
    def valid_type(o_type):
        if o_type.lower() == "box" or o_type.lower() == "letter":
            return True
        else:
            print("- - -Invalid type of item type- - -")
            return False

    @staticmethod
    def valid_price(price):
        y = str(price).split('.')
        if len(y[-1]) == 2:
            return True
        else:
            print("- - -Invalid type of price- - -")
            return False

    @staticmethod
    def valid_data(data):
        if re.sub(r"[a-zA-Z]", "X", data):
            return True
        else:
            print("- - -Invalid type of data- - -")
            return False
