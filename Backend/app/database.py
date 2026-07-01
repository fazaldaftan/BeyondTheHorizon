from sqlalchemy import create_engine, Column, Integer, String, Float, Text
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker
import os

DATABASE_URL = os.getenv("DATABASE_URL", "postgresql://user:pass@localhost:5432/bth_db")

engine = create_engine(DATABASE_URL)
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)
Base = declarative_base()

class Player(Base):
    __tablename__ = "players"
    id = Column(String, primary_key=True, index=True)
    credits = Column(Float, default=0.0)
    research_points = Column(Integer, default=0)
    # Add more as needed

class Discovery(Base):
    __tablename__ = "discoveries"
    id = Column(Integer, primary_key=True, index=True)
    player_id = Column(String, index=True)
    planet_seed = Column(Integer)
    name = Column(String)
    scientific_value = Column(Float)
    data = Column(Text)  # JSON serialized

Base.metadata.create_all(bind=engine)