using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text CountText;
	public Text WinText;
	private int count;

	void start ()
	{
		count = 0;
		CountText = GetComponent<Text> ();
		WinText = GetComponent<Text> ();
		WinText.text = "";
		SetCountText ();

	}


	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce (movement * speed * Time.deltaTime);


	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}

	 void SetCountText(){
		CountText.text = "Count: " + count.ToString();
		if (count >= 12) {
			WinText.text = "YOU WIN!";
		}

	}
}
