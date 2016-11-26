using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed = 30;
    public Text countText;
    public float size = 1;
    public Rigidbody rb;
    private int count;
    private int timer;
	// Use this for initialization
	void Start () {
        count = 0;
        countText.text = "count: " + count;
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (timer>0)
        {
            timer--;
        }
        else
        {
            timer = 0;
            speed = 30;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed / size);

		if (Mathf.Pow(transform.position.x,2f) > Mathf.Pow(50f,2f) || Mathf.Pow(transform.position.z,2f) > Mathf.Pow(50f,2f))
        {
			transform.position = new Vector3(0f,0f,0f);
        }
    }
    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.CompareTag("Pick Up(food)"))
        {
            Destroy(other.gameObject);
            count++;
            aftercount();
        }
        if (other.gameObject.CompareTag("Pick Up(speeder)"))
        {
            Destroy(other.gameObject);
            afterspeed();
        }
        if (other.gameObject.CompareTag("Pick Up(power)"))
        {
            Destroy(other.gameObject);
            afterpower();
        }
		if (other.gameObject.CompareTag("Player")) {
			if (other.gameObject.GetComponent<PlayerController> ().size > size) {
				initiate ();
			} else {
				count++;
				aftercount();
			}
		}
    }

    void aftercount()
    {
        size = (Mathf.Log10(count + 1) + 1) + count*0.1f;
        countText.text = "count: " + count;
        transform.localScale = new Vector3(size, size, size);
    }
    void afterspeed()
    {
        timer = 1000;
        speed *= 2;
		if (speed/size > 120f) {
			speed = 120f * size;
		}
    }
    void afterpower()
    {

    }
	void initiate(){
		transform.position = new Vector3(0f,0f,0f);
		size = 1;
		speed = 30;
	}
}
