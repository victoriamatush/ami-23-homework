import re


class Validation:

    @staticmethod
    def is_digit(func):
        def wrapper(item, num):
            if not str(num).isdigit():
                raise Exception('- - -Invalid type of number- - -')
            return func(item, num)

        return wrapper

    @staticmethod
    def valid_code(func):
        def wrapper(item, code):
            if not re.match(r'[0-9]{3}[-][0-9]{3}[-][0-9]{3}', code):
                raise Exception("- - -Invalid type of code- - -")
            return func(item, code)

        return wrapper

    @staticmethod
    def valid_title(func):
        def wrapper(item, title):
            if not re.fullmatch(r'[a-zA-z]+', title, re.IGNORECASE):
                raise Exception("- - -Invalid type of title- - -")
            return func(item, title)

        return wrapper

    @staticmethod
    def valid_type(func):
        def wrapper(item, o_type):
            if o_type.lower() != "box" and o_type.lower() != "letter":
                raise Exception("- - -Invalid type of item type- - -")
            return func(item, o_type)

        return wrapper

    @staticmethod
    def valid_price(func):
        def wrapper(item, price):
            if round(price, 2) != price:
                raise Exception("- - -Invalid type of price- - -")
            return func(item, price)

        return wrapper

    @staticmethod
    def valid_data(func):
        def wrapper(item, data):
            pattern = re.compile("[@_!#$%^&*()?/\|{}~`:;-]")
            if pattern.search(data):
                raise Exception("- - -Invalid type of data- - -")
            return func(item, data)

        return wrapper