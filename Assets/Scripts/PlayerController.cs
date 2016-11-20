using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text countText;
    public float size;
    private Rigidbody rb;
    private int count;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "count: " + count;
        size = 1;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed / size);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            Destroy(other.gameObject);
            count++;
            aftercount();
        }
    }

    void aftercount()
    {
        size = (Mathf.Log10(count + 1) + 1);
        countText.text = "count: " + count;
        transform.localScale = new Vector3(size, size, size);
    }
}
