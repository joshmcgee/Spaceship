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
	private Vector3 originPosition;

	private float offsetRotation;
	private float originRotation;


	void Start () {
		originPosition = transform.localPosition;
		originRotation = transform.localRotation.eulerAngles.z;
	}

	// Update is called once per frame
	void Update () {

		// Translation Sway.
		offsetPosition.x = Mathf.Sin(Time.time * xFrequency) * xAmplitude;
		offsetPosition.y = Mathf.Cos(Time.time * yFrequency) * yAmplitude;

		transform.localPosition = originPosition + offsetPosition;


		// Rotation Sway.
		offsetRotation = Mathf.Sin(Time.time * rFrequency) * rAmplitude;
		offsetRotation += originRotation;
		transform.localRotation = Quaternion.Euler(0, 0, originRotation + offsetRotation);
	}
}
