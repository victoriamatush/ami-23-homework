from datetime import datetime, date, time
from time import strptime


class Employee:

    name: str
    salary: float
    first_working_date: datetime.date
    last_working_date: datetime.date

    def __init__(self, name, salary, first_working_date, last_working_date):
        self.name = name
        self.salary = salary
        self.first_working_date = first_working_date
        self.last_working_date = last_working_date

    def __repr__(self):
        return f"<Goods[name='{self.name}',salary='{float(self.salary)}'," \
               f"first_working_date='{strptime(self.first_working_date, format='%d %m %Y')}'," \
               f"last_working_date='{date(self.last_working_date)}'>"

    def __str__(self):
        return f'{[self.name, self.salary, self.first_working_date, self.last_working_date]!r}'

    def output(self):
        print("-- -- -- -- -- -- --")
        print("Name:", self.name)
        print("Salary:", self.salary)
        print("first_working_date:", self.first_working_date)
        print("last_working_date:", self.last_working_date)

    def to_dict(self):
        """Converts input data to dictionary"""
        return {
            "name": self.name,
            "salary": float(self.salary),
            "first_working_date": self.first_working_date,
            "last_working_date": self.last_working_date
        }
