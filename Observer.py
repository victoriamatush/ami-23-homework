class Observer:
    l = dict()

    @staticmethod
    def attach(key, method):
        Observer.l[key] = method


class Event:
    @staticmethod
    def update(key, former, pos, result=None):
        for l in Observer.l:
            if key == l:
                if result is not None:
                    Observer.l[l](former, pos, result)
                else:
                    Observer.l[l](former, pos)
                break