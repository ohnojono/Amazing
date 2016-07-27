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


	void FixedUpdate ()
	{
		float moveHorizontal = Input.acceleration.x * 1.0f;
		float moveVertical = Input.acceleration.y * 1.0f;

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

