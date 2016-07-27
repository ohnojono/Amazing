using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	private Scene activeScene;

	private bool isColliding = false;


	void Start ()
	{
		activeScene = SceneManager.GetActiveScene();

		rb = GetComponent<Rigidbody>();
	}


	void FixedUpdate ()
	{
		float moveHorizontal = Input.acceleration.x * 1.5f;
		float moveVertical = Input.acceleration.y * 1.5f;

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Complete")) {
			isColliding = true;
			Destroy (other.gameObject);
		}
	}

	void Update(){
		if (isColliding) {
			scoremanager.score++;
			Debug.Log (scoremanager.score);
			restartLevel ();
			isColliding = false;
		}
	}

	public void restartLevel(){
		SceneManager.LoadScene (activeScene.buildIndex);
		isColliding = false;

	}

}

