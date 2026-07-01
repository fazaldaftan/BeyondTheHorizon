using UnityEngine;
using Photon.Pun; // Or Mirror, Netcode - Photon recommended for ease

/// <summary>
/// Multiplayer foundations: Co-op exploration, shared discoveries.
/// Uses Photon or Unity Netcode for scalability.
/// </summary>
public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    public static MultiplayerManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void JoinExplorationSession(string roomCode)
    {
        PhotonNetwork.JoinOrCreateRoom(roomCode, new RoomOptions { MaxPlayers = 4 }, null);
    }

    public override void OnJoinedRoom()
    {
        // Spawn player avatar, sync planet state
        Debug.Log("Joined co-op session - Shared discoveries enabled");
    }

    // Sync discoveries, events, positions (via RPC/PhotonView)
}