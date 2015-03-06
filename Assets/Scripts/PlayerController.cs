using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	private int count;
	public GUIText countText;
	public GUIText winText;

	void Start() {
		count = 0;
		UpdateItemCount();
		winText.text = string.Empty;
	}

    // physics calculations are applied right before this func
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		// Time.deltaTime ensures framerate smoothness
		rigidbody.AddForce(movement * speed * Time.deltaTime);
    }

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			count++;
			UpdateItemCount();
		}
	}

	void UpdateItemCount() {
		countText.text = "Count: " + count.ToString();
		if (count >= 14) {
			winText.text = "You Win!";
		}
	}
}