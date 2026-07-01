from fastapi import APIRouter, Depends, HTTPException
from fastapi.security import OAuth2PasswordBearer
from jose import JWTError, jwt
from datetime import datetime, timedelta

router = APIRouter(prefix="/auth", tags=["auth"])

oauth2_scheme = OAuth2PasswordBearer(tokenUrl="token")
SECRET_KEY = "your-secret-key-change-in-prod"  # Use env var
ALGORITHM = "HS256"

@router.post("/token")
async def login():
    # TODO: Full OAuth/JWT with user repo
    access_token = jwt.encode({"sub": "player1"}, SECRET_KEY, algorithm=ALGORITHM)
    return {"access_token": access_token, "token_type": "bearer"}