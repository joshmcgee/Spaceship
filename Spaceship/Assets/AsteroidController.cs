using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {

	public float minRotationSpeed;
	public float maxRotationSpeed;

	// Use this for initialization
	void Start () {
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));

		ApplyRandomRotation(minRotationSpeed, maxRotationSpeed);
	}

	void ApplyRandomRotation (float min, float max) {
		float speed = Random.Range(min, max);
		if (Random.value > 0.5f) {
			speed *= -1;
		}

		rigidbody2D.angularVelocity = speed;
	}
}
