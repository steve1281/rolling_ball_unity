using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float speed;

	private Rigidbody rb;
	void Start()
	{
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
        	}
    	}
}
