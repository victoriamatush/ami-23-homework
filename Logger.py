class Logger:
    file = 'logger.txt'

    @staticmethod
    def Add(former, pos, result):
        with open(Logger.file, 'a') as file:
            file.write('Starting List:' + str(former) +
                       '\nPosition of adding:' + str(pos) +
                       '\nNew list:' + str(result) + '\n\n')

    @staticmethod
    def Delete(former, pos, result):
        with open(Logger.file, 'a') as file:
            if isinstance(pos, list):
                file.write('Starting List:' + str(former) +
                           '\nRange of deleting:' + str(pos) +
                           '\nNew list:' + str(result) + '\n\n')
            else:
                file.write('Starting List:' + str(former) +
                           '\nPosition of deleting:' + str(pos) +
                           '\nNew list' + str(result) + '\n\n')

    @staticmethod
    def Method(former, result):
        with open(Logger.file, 'a') as file:
            file.write('Starting List:' + str(former) +
                       '\nNew list:' + str(result) + '\n\n')