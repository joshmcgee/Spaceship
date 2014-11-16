using UnityEngine;
using System.Collections;

public class ShipInputController : MonoBehaviour {

	public float maxEngineThrust;
	public float engineThrottleSpeed;
	private float engineThrust;
	public float maxLongitudinalThrust;
	public float maxLateralThrust;
	public float maxRotationalThrust;

	Vector3 currentThrust;
	

	// Update is called once per frame
	void Update () {
		GetInput();
	}

	void FixedUpdate () {
		ApplyCurrentThrust();
	}

	void GetInput () {
		GetLongitudeThrust();
		GetLateralThrust();
		GetRotationalThrust();
	}

	void GetLongitudeThrust () {
		float longitudeThrust = GetLongitudeThrusters();
		engineThrust = GetEngineThrust();

		currentThrust.y = (longitudeThrust + engineThrust) * Time.deltaTime;
	}

	float GetLongitudeThrusters () {
		return Input.GetAxis("Longitudinal Thrusters") * maxLongitudinalThrust;
	}

	float GetEngineThrust () {
		float throttleAdjust = engineThrottleSpeed * Input.GetAxis("Engine Throttle") * maxEngineThrust * Time.deltaTime;
		engineThrust += throttleAdjust;

		if (engineThrust > maxEngineThrust) {
			engineThrust = maxEngineThrust;
		}
		else if (engineThrust < 0f) {
			engineThrust = 0f;
		}

		//Debug.Log("Engine Throttle => " + Mathf.Floor(engineThrust / maxEngineThrust * 100));
		return engineThrust;
	}

	void GetLateralThrust () {

		currentThrust.x = GetLateralThrusters() * Time.deltaTime;
	}

	float GetLateralThrusters () {
		return Input.GetAxis("Lateral Thrusters") * maxLateralThrust;
	}

	void GetRotationalThrust () {
		currentThrust.z = GetRotationalThrusters() * Time.deltaTime;
	}

	float GetRotationalThrusters () {
		return Input.GetAxis("Rotational Thrusters") * maxRotationalThrust;
	}

	void ApplyCurrentThrust () {
		rigidbody2D.AddRelativeForce(new Vector2(currentThrust.x, currentThrust.y));

		rigidbody2D.AddTorque(currentThrust.z);
	}
}











