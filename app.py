from flask import Flask, render_template, request
from flask_sqlalchemy import SQLAlchemy
from sqlalchemy import create_engine
from sqlalchemy.orm import Session, sessionmaker
import enum

application = Flask(__name__)

application.config['SQLALCHEMY_DATABASE_URI'] = 'postgresql://postgres:qwerty@localhost/Goods'      # postgres : postgresspass — ЗМІНИТИ НА СВІЙ ЛОГІН І ПАРОЛЬ БД

database = SQLAlchemy(application)
engine = create_engine('postgresql://postgres:qwerty@localhost/Goods')
Session = sessionmaker(bind=engine)
session = Session()

