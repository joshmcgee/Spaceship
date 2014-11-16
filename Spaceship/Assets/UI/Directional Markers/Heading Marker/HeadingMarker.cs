using UnityEngine;
using System.Collections;

public class HeadingMarker : DirectionalMarker {

	// Generic
	public float minVisibleVelocity = 0.2f;
	private Rigidbody2D shipRigidbody;


	/*// Neck
	public float neckLength = 5.0f;
	public float neckWidth = 2.0f;
	private GameObject neckObject;
	private LineRenderer neckLine;

	// Base
	public float baseWidth = 2.0f;
	public float baseAngle = 1.0f;
	public int baseSegments = 5;
	public float baseRadius = 80.0f;
	private GameObject baseObject;
	private LineRenderer baseLine;

	public Material material;*/

	// Use this for initialization
	void Start () {
		Init();
	}

	new protected void Init () {
		shipRigidbody = transform.rigidbody2D;
		base.Init();
	}

	protected new IEnumerator MarkerUpdate() {
		while (true) {
			// Follow the target.
			PointAtLocation(shipRigidbody.velocity, targetIsRelative);

			// Enable / Disable the marker as needed.
			CheckVisibility();
			
			yield return new WaitForSeconds(trackingUpdateDelay);
		}
	}

	void CheckVisibility () {
		if (shipRigidbody.velocity.magnitude > minVisibleVelocity) {
			EnableMarker();
		}
		else {
			DisableMarker();
		}
	}
}
















