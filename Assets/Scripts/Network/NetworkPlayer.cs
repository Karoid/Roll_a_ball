using UnityEngine;
using System.Collections;

public class NetworkPlayer : Photon.MonoBehaviour {
    public GameObject myCamera;
    public GameObject myPlayer;
    public GameObject myCanvas;
	// Use this for initialization
	void Start () {
        if (photonView.isMine)
        {
            myCamera.SetActive(true);
            myCanvas.SetActive(true);
            myPlayer.GetComponent<PlayerController>().enabled = true;
			myPlayer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			myPlayer.GetComponent<SphereCollider>().isTrigger= false;
        }
	}
}
