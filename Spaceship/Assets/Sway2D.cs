using UnityEngine;
using System.Collections;

public class Sway2D : MonoBehaviour {

	public float xFrequency;
	public float xAmplitude;

	public float yFrequency;
	public float yAmplitude;

	public float rFrequency;
	public float rAmplitude;

	private Vector3 offsetPosition;
	private Vector3 originalPosition;

	private Quaternion offsetRotation;
	private Quaternion originalRotation;


	void Start () {
		originalPosition = transform.localPosition;
		originalRotation = transform.localRotation;
	}

	// Update is called once per frame
	void Update () {
		offsetPosition.x = Mathf.Sin(Time.time * xFrequency) * xAmplitude;
		offsetPosition.y = Mathf.Cos(Time.time * yFrequency) * yAmplitude;

		transform.localPosition = originalPosition + offsetPosition;

		offsetRotation = Quaternion.Euler(0f, 0f, Mathf.Sin(Time.time * rFrequency) * rAmplitude);
		transform.localRotation = offsetRotation;

	}
}
