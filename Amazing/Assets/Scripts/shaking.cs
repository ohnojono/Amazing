using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class shaking : MonoBehaviour {

	private Scene activeScene;


	public float accelerometerUpdateInterval =  1.0f / 60.0f;
	// The greater the value of LowPassKernelWidthInSeconds, the slower the filtered value will converge towards current input sample (and vice versa).
	public float lowPassKernelWidthInSeconds =  1.0f;
	// This next parameter is initialized to 2.0 per Apple's recommendation, or at least according to Brady! ;)
	public float shakeDetectionThreshold = 2.0f;

	public float lowPassFilterFactor;
	private Vector3 lowPassValue = Vector3.zero;
	private Vector3 acceleration;
	private Vector3 deltaAcceleration;

	void Start (){
		activeScene = SceneManager.GetActiveScene();

		lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;

		shakeDetectionThreshold *= shakeDetectionThreshold;
		lowPassValue = Input.acceleration;
	}

	void Update ()
	{
		acceleration = Input.acceleration;
		lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
		deltaAcceleration = acceleration - lowPassValue;
		if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
		{
			// Perform your "shaking actions" here, with suitable guards in the if check above, if necessary to not, to not fire again if they're already being performed.
			Debug.Log("Shake event detected at time "+Time.time);
			scoremanager.score = 0;
			SceneManager.LoadScene (activeScene.buildIndex);
		
		}
	}
}