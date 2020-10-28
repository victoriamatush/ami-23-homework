import re


class Goods:

    id: int
    code: str
    title: str
    type: str
    amount: int
    price: float
    data: str

    def __init__(self, id, code, title, type, amount, price, data):
        self.id = id
        self.code = code
        self.title = title
        self.type = type
        self.amount = amount
        self.price = price
        self.data = data

    def __repr__(self):
        return f"<Goods[id='{int(self.id)}',code='{self.code}',title='{self.title}',type='{self.type}'" \
               f",amount='{int(self.amount)}',price='{float(self.price)}',data='{self.data}'>"

    def __str__(self):
        return f'{[int(self.id), self.code, self.title, self.type, self.amount, self.price, self.data]!r}'

    def output(self):
        print("-- -- -- -- -- -- --")
        print("Id:", self.id)
        print("Code:", self.code)
        print("Title:", self.title)
        print("Type:", self.type)
        print("Amount:", self.amount)
        print("Price:", self.price)
        print("Data:", self.data)

    def to_dict(self):
        """Converts input data to dictionary"""
        return {
            "id": int(self.id),
            "code": self.code,
            "title": self.title,
            "type": self.type,
            "amount": int(self.amount),
            "price": float(self.price),
            "data": self.data
        }

    def attr_arr(self):
        arr = [str(self.id), self.code, self.title, self.type, str(self.amount), str(self.price), self.data]
        return arr
