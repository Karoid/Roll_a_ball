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
	private int food_count;
	private int speeder_count;
	private int power_count;
    public Transform SpawnPoint;
    // Use this for initialization
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(VERSION);
        PhotonNetwork.automaticallySyncScene = true;
		food_count = 0;
		speeder_count = 0;
		power_count = 0;
    }

    void Update()
    {
        if (Random.value < 0.005 && food_count < 30)
        {
            PhotonNetwork.Instantiate(food, new Vector3(Random.value * 100 - 50f, 0.5f, Random.value * 100 - 50f), Quaternion.identity, 0);
			food_count++;
        }
		if (Random.value < 0.0005 && speeder_count < 10)
        {
            PhotonNetwork.Instantiate(speeder, new Vector3(Random.value * 100 - 50f, 0.5f, Random.value * 100 - 50f), Quaternion.identity, 0);
			speeder_count++;
        }
		if (Random.value < 0.0001 && power_count < 5)
        {
            PhotonNetwork.Instantiate(power, new Vector3(Random.value * 100 - 50f, 0.5f, Random.value * 100 - 50f), Quaternion.identity, 0);
			power_count++;
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

