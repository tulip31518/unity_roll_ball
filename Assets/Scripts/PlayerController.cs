using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public int count;
	public Text countText;
	public Text winText;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText (); 
	}

	void FixedUpdate()
	{
		float moveHorizental =  Input.GetAxis ("Horizontal");
		float moveVertical =  Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizental, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count == 12) 
		{
			winText.gameObject.SetActive(true);
			winText.text = "You Win";
		}
	}

}
