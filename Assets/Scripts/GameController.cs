using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject food;
	public GameObject speeder;
	public GameObject power;

	void Update(){
		if (Random.value < 0.005) {
			Instantiate(food, new Vector3(Random.value * 100 - 50f, 0.5f, Random.value * 100 - 50f), Quaternion.identity);		
		}
		if (Random.value < 0.0001) {
			Instantiate(speeder, new Vector3(Random.value * 100 - 50f, 0.5f, Random.value * 100 - 50f), Quaternion.identity);		
		}
	}
}
