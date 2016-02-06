using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour {
	public float speed;
    public Text countText;
    public Text winText;


	private Rigidbody rb;
    private int count; // count the blocks we pick up.
	void Start()
	{
        count = -1;
        IncrementCount();
        winText.text = "";

		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
	}

	void FixedUpdate()
	{
	// fixed is where physics go. We want to apply forces to our player.  This is physics. So this is where are code will go.
      		float moveHorizontal = Input.GetAxis("Horizontal");
      		float moveVertical = Input.GetAxis("Vertical");
                Vector3 movement  = new Vector3 (moveHorizontal, 0 , moveVertical);
		rb.AddForce(movement *speed);
	}

	void OnTriggerEnter(Collider other) 
	{
        	if (other.gameObject.CompareTag ("Pick Up"))  // you need to set the tag on the prefab to "Pick Up"
        	{
        		other.gameObject.SetActive (false);
                IncrementCount();
        	}
    }

    void IncrementCount()
    {
        count = count + 1;
        countText.text = "Count: " + count.ToString();
        if (count >= 6) {
            winText.text = "YOU WIN";
        }

    }
}
