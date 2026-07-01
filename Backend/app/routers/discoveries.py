from fastapi import APIRouter, Depends
from pydantic import BaseModel

router = APIRouter(prefix="/discoveries", tags=["discoveries"])

class Discovery(BaseModel):
    player_id: str
    planet_seed: int
    discovery_type: str
    name: str
    scientific_value: float

@router.post("/")
async def log_discovery(discovery: Discovery):
    # TODO: Save to PostgreSQL via repository
    return {"status": "logged", "points_awarded": int(discovery.scientific_value * 10)}

# Add to main.py later: app.include_router(router)