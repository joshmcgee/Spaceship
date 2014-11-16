using UnityEngine;
using System.Collections;

public class ShipNavigationController : MonoBehaviour {

	public float maxEngineThrust;
	public float engineThrottleSpeed;
	private float engineThrust;
	public float maxLongitudinalThrust;
	public float maxLateralThrust;
	public float maxRotationalThrust;

	public float dampenerTranslationThreshold;
	public float dampenerRotationThreshold;

	Vector3 currentThrust;
	private Vector3 localVelocity;
	

	// Update is called once per frame
	void Update () {

		currentThrust = Vector3.zero;
		GetInput();
	}

	void FixedUpdate () {
		ApplyCurrentThrust();
		
		//localVelocity = transform.InverseTransformDirection(rigidbody2D.velocity);
		//Debug.Log("localVelocity => " + localVelocity + "\nrigidVelocity => " + rigidbody2D.velocity);
	}

	void GetInput () {
		GetLongitudeThrust();
		GetLateralThrust();
		GetRotationalThrust();

		if (Input.GetButton("Inertial Dampeners")) {
			ApplyDampeners();
		}
	}


	//------------------
	// Velocity Control
	//------------------

	void GetLongitudeThrust () {
		float longitudeThrust = GetLongitudeThrusters();
		engineThrust = GetEngineThrust();

		currentThrust.y += (longitudeThrust + engineThrust) * Time.deltaTime;
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

		currentThrust.x += GetLateralThrusters() * Time.deltaTime;
	}

	float GetLateralThrusters () {
		return Input.GetAxis("Lateral Thrusters") * maxLateralThrust;
	}

	void GetRotationalThrust () {
		currentThrust.z += GetRotationalThrusters() * Time.deltaTime;
	}

	float GetRotationalThrusters () {
		return Input.GetAxis("Rotational Thrusters") * maxRotationalThrust;
	}

	void ApplyCurrentThrust () {
		rigidbody2D.AddRelativeForce(new Vector2(currentThrust.x, currentThrust.y));

		rigidbody2D.AddTorque(currentThrust.z);
	}


	//--------------------
	// Velocity Dampening
	//--------------------

	void ApplyDampeners () {
		localVelocity = transform.InverseTransformDirection(rigidbody2D.velocity);

		ApplyLongitudinalDampeners();
		ApplyLateralDampeners();
		ApplyRotationalDampeners();
	}

	void ApplyLongitudinalDampeners () {
		if (localVelocity.y > 0) {
			if (localVelocity.y > dampenerTranslationThreshold) {
				currentThrust.y -= maxLongitudinalThrust * Time.deltaTime;
			}
			else {
				float dampenerThrottle = (localVelocity.y / dampenerTranslationThreshold) * maxLongitudinalThrust;
				currentThrust.y -= dampenerThrottle * Time.deltaTime;
			}
		}
		else if (localVelocity.y < 0) {
			if (localVelocity.y < -dampenerTranslationThreshold) {
				currentThrust.y += maxLongitudinalThrust * Time.deltaTime;
			}
			else {
				float dampenerThrottle = (-localVelocity.y / dampenerTranslationThreshold) * maxLongitudinalThrust;
				currentThrust.y += dampenerThrottle * Time.deltaTime;
			}
		}
	}

	void ApplyLateralDampeners () {
		if (localVelocity.x > 0) {
			if (localVelocity.x > dampenerTranslationThreshold) {
				currentThrust.x -= maxLateralThrust * Time.deltaTime;
			}
			else {
				float dampenerThrottle = (localVelocity.x / dampenerTranslationThreshold) * maxLateralThrust;
				currentThrust.x -= dampenerThrottle * Time.deltaTime;
			}
		}
		else if (localVelocity.x < 0) {
			if (localVelocity.x < -dampenerTranslationThreshold) {
				currentThrust.x += maxLateralThrust * Time.deltaTime;
			}
			else {
				float dampenerThrottle = (-localVelocity.x / dampenerTranslationThreshold) * maxLateralThrust;
				currentThrust.x += dampenerThrottle * Time.deltaTime;
			}
		}
	}

	void ApplyRotationalDampeners () {

		//Debug.Log("angularVelocity => " + rigidbody2D.angularVelocity);

		if (rigidbody2D.angularVelocity > 0) {
			if (rigidbody2D.angularVelocity > dampenerRotationThreshold) {
				currentThrust.z -= maxRotationalThrust * Time.deltaTime;
			}
			else {
				float dampenerThrottle = (rigidbody2D.angularVelocity / dampenerRotationThreshold) * maxRotationalThrust;
				currentThrust.z -= dampenerThrottle * Time.deltaTime;
			}
		}
		else if (rigidbody2D.angularVelocity < 0) {
			if (rigidbody2D.angularVelocity < dampenerRotationThreshold) {
				currentThrust.z += maxRotationalThrust * Time.deltaTime;
			}
			else {
				float dampenerThrottle = (-rigidbody2D.angularVelocity / dampenerRotationThreshold) * maxRotationalThrust;
				currentThrust.z += dampenerThrottle * Time.deltaTime;
			}
		}
	}
}











