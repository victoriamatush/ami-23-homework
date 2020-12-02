from validation import Validation


class Goods:

    # id: int
    code: str
    title: str
    type: str
    amount: int
    price: float
    data: str

    def __init__(self):
        self._id = 0
        self._code = ""
        self._title = ""
        self._type = ""
        self._amount = 0
        self._price = 0.0
        self._data = ""

    @property
    def id(self):
        return self._id

    @id.setter
    @Validation.is_digit
    def id(self, value):
        self._id = value

    @property
    def code(self):
        return self._code

    @code.setter
    @Validation.valid_code
    def code(self, value):
        self._code = value

    @property
    def title(self):
        return self._title

    @title.setter
    @Validation.valid_title
    def title(self, value):
        self._title = value

    @property
    def type(self):
        return self._type

    @type.setter
    @Validation.valid_type
    def type(self, value):
        self._type = value

    @property
    def amount(self):
        return self._amount

    @amount.setter
    @Validation.is_digit
    def amount(self, value):
        self._amount = value

    @property
    def price(self):
        return self._price

    @price.setter
    @Validation.valid_price
    def price(self, value):
        self._price = value

    @property
    def data(self):
        return self._data

    @data.setter
    @Validation.valid_data
    def data(self, value):
        self._data = value

    def __repr__(self):
        return f"<Goods[id='{int(self._id)}',code='{self.code}',title='{self.title}',type='{self.type}'" \
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

