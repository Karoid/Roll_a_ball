using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public GameObject food;
	public GameObject speeder;
	public GameObject power;
    public GameObject pickups;

    void Update(){
		if (Random.value < 0.005) {
            GameObject childObject1 = Instantiate(food, new Vector3(Random.value * 100 - 50f, 0.5f, Random.value * 100 - 50f), Quaternion.identity) as GameObject;
            childObject1.transform.parent = pickups.transform;
        }
		if (Random.value < 0.0005) {
            GameObject childObject2 = Instantiate(speeder, new Vector3(Random.value * 100 - 50f, 0.5f, Random.value * 100 - 50f), Quaternion.identity) as GameObject;
            childObject2.transform.parent = pickups.transform;
        }
        if (Random.value < 0.0001)
        {
            GameObject childObject3 = Instantiate(power, new Vector3(Random.value * 100 - 50f, 0.5f, Random.value * 100 - 50f), Quaternion.identity) as GameObject;
            childObject3.transform.parent = pickups.transform;
        }
    }
}
