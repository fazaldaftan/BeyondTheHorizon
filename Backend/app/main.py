from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
import uvicorn

app = FastAPI(title="Beyond the Horizon Backend")

app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],  # Configure properly in prod
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

@app.get("/")
async def root():
    return {"message": "Beyond the Horizon API is running"}

from .routers import auth, discoveries

app.include_router(auth.router)
app.include_router(discoveries.router)

if __name__ == "__main__":
    uvicorn.run(app, host="0.0.0.0", port=8000)