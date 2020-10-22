


class Validation:

    @staticmethod
    def valid_name(value):
        x = isinstance(value, str)
        if x:
            return True
        else:
            raise ValueError

    @staticmethod
    def valid_salary(value):
        y = str(value).split('.')
        if len(y[-1]) == 2:
            return True
        else:
            raise ValueError
