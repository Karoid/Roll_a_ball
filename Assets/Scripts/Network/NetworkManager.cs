using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour
{
    const string VERSION = "v0.0.1";
    public string roomName = "room";
    private string playerPrefabName = "PlayComponent";
    private string food = "Pick up(food)";
    private string speeder = "Pick up(speeder)";
    private string power = "Pick up(power)";
    public Transform SpawnPoint;
    // Use this for initialization
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(VERSION);
        PhotonNetwork.automaticallySyncScene = true;
    }

    void Update()
    {
        if (Random.value < 0.005)
        {
            GameObject childObject1 = PhotonNetwork.Instantiate(food, new Vector3(Random.value * 100 - 50f, 0.5f, Random.value * 100 - 50f), Quaternion.identity, 0) as GameObject;
        }
        if (Random.value < 0.0005)
        {
            GameObject childObject2 = PhotonNetwork.Instantiate(speeder, new Vector3(Random.value * 100 - 50f, 0.5f, Random.value * 100 - 50f), Quaternion.identity, 0) as GameObject;
        }
        if (Random.value < 0.0001)
        {
            GameObject childObject3 = PhotonNetwork.Instantiate(power, new Vector3(Random.value * 100 - 50f, 0.5f, Random.value * 100 - 50f), Quaternion.identity, 0) as GameObject;
        }
    }

    void OnJoinedLobby()
    {
        RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(playerPrefabName, SpawnPoint.position, SpawnPoint.rotation, 0);
    }
    void OnPhotonJoinFailed()
    {
        Debug.Log("Can't join random room!");
    }
}

