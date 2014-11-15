using UnityEngine;
using System.Collections;

public class Craft : MonoBehaviour {

	public float maxForwardThrust = 10.0f;
	public float maxReverseThrust = 8.0f;
	public float maxLateralThrust = 3.0f;
	public float maxRotationThrust = 3.0f;

	private Vector2 currentThrustVector;
	private float currentLongitudeThrust = 0.0f;
	private float currentLateralThrust = 0.0f;
	private float currentRotationThrust = 0.0f;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate () {
		ApplyCurrentThrust();
	}
	
	// Update is called once per frame
	void Update () {
		GetPilotInput();
	}

	private void GetPilotInput () {
		GetLongitudeThrust();
		GetLateralThrust();
		GetRotationThrust();
	}

	private void GetLongitudeThrust () {
		currentLongitudeThrust = Input.GetAxis("Longitude Thrust") * Time.deltaTime;
		
		// Forward Thrusters
		if (currentLongitudeThrust > 0.0f) {
			currentLongitudeThrust *= maxForwardThrust;
		}
		// Reverse Thrusters
		else if (currentLongitudeThrust < 0.0f) {
			currentLongitudeThrust *= maxReverseThrust;
		}
	}

	private void GetLateralThrust () {
		currentLateralThrust = Input.GetAxis("Lateral Thrust") * maxLateralThrust * Time.deltaTime;
	}

	private void GetRotationThrust () {
		currentRotationThrust = Input.GetAxis("Rotational Thrust") * maxRotationThrust * Time.deltaTime;
	}

	private void ApplyCurrentThrust () {
		currentThrustVector = new Vector2(currentLateralThrust, currentLongitudeThrust);
		rigidbody2D.AddRelativeForce(currentThrustVector);

		rigidbody2D.AddTorque(currentRotationThrust);
	}
}















