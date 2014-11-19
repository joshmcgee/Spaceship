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

	public float updateRate;
	private float updateDelay;


	void Start () {

		// Save the original position and rotation.
		originPosition = transform.localPosition;
		originRotation = transform.localRotation.eulerAngles.z;

		// Calculate how often to update.
		if (updateRate > 0f) {
			updateDelay = 1f/updateRate;
		}
		else {
			updateDelay = 0f;
		}

		// Begin!
		StartCoroutine("SwayUpdate");
	}

	IEnumerator SwayUpdate () {

		while (true) {
			// Translation Sway.
			offsetPosition.x = Mathf.Sin(Time.time * xFrequency) * xAmplitude;
			offsetPosition.y = Mathf.Cos(Time.time * yFrequency) * yAmplitude;
			
			transform.localPosition = originPosition + offsetPosition;
			
			
			// Rotation Sway.
			offsetRotation = Mathf.Sin(Time.time * rFrequency) * rAmplitude;
			offsetRotation += originRotation;
			transform.localRotation = Quaternion.Euler(0, 0, originRotation + offsetRotation);

			yield return new WaitForSeconds(updateDelay);
		}
	}
}
