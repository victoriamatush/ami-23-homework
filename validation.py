
class Validation:

    @staticmethod
    def f_exists(filename):
        import pathlib
        db_file = pathlib.Path(filename)
        if db_file.exists():
            return True
        else:
            print("- - -File is not exist- - -")
            return False

    @staticmethod
    def f_is_empty(filename):
        if len(filename) > 0:
            return True
        else:
            print("- - -File is empty- - -")
            return False

    @staticmethod
    def validateContext(val):
        if val.strategy():
            return True
        else:
            print("- - -Ypu should choose strategy- - -")
            return False

