using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	private Scene activeScene;


	void Start ()
	{
		activeScene = SceneManager.GetActiveScene();

		rb = GetComponent<Rigidbody>();
	}

	void Update(){
//		transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
	}


	void FixedUpdate ()
	{
		//iPad
		float moveHorizontal = Input.acceleration.x * 1.0f;
		float moveVertical = Input.acceleration.y * 1.0f;

//v2	float moveHorizontal = 0.0f;
//		float moveVertical = 0.0f;


//v2		if (Input.GetKey (KeyCode.F)) {
//			moveHorizontal = -1.0f;
//		}
//
//		if (Input.GetKey (KeyCode.T)) {
//			moveHorizontal = 1.0f;
//		}
//
//		if (Input.GetKey (KeyCode.D)) {
//			moveVertical = -1.0f;
//		}
//
//		if (Input.GetKey (KeyCode.E)) {
//			moveVertical = 1.0f;
//		}

//v1	Input.GetKey (KeyCode.H);

		//float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Complete")) {
			Destroy (other.gameObject);
			scoremanager.score++;
			restartLevel ();

		}
	}

	public void restartLevel(){
		SceneManager.LoadScene (activeScene.buildIndex);
	}

}

