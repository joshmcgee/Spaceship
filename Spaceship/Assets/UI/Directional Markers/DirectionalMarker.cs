using UnityEngine;
using System.Collections;

public class DirectionalMarker : MonoBehaviour {

	// Generic
	public Material material;

	// Neck
	public float neckLength = 5.0f;
	public float neckWidth = 2.0f;
	protected GameObject neckObject;
	protected LineRenderer neckLine;
	
	// Base
	public float baseWidth = 2.0f;
	public float baseAngle = 1.0f;
	public int baseSegments = 5;
	public float baseRadius = 80.0f;
	protected GameObject baseObject;
	protected LineRenderer baseLine;

	// Target
	public Vector3 targetLocation;
	public bool targetIsRelative = false;
	public float trackingUpdateRate = 0.0f; // 0.0 => every frame
	protected float trackingUpdateDelay = 0.0f;



	// Creation Functions

	void Start () {
		Init();
	}
	
	protected void Init () {
		// Create the actual marker.
		PointAtLocation(Vector3.right, true);
		CreateBase();
		CreateNeck();

		// Setup updates
		if (trackingUpdateRate == 0.0f) {
			trackingUpdateDelay = 0.0f;
		}
		else {
			trackingUpdateDelay = 1 / trackingUpdateRate;
		}
		StartCoroutine("MarkerUpdate");
	}

	protected void CreateBase() {
		// Create the object.
		baseObject = new GameObject();
		baseObject.transform.position = transform.position;
		baseObject.name = "Base";
		baseObject.transform.parent = transform;
		
		// Create the line renderer.
		baseLine = baseObject.AddComponent<LineRenderer>();
		baseLine.useWorldSpace = false;
		baseLine.SetWidth(baseWidth, baseWidth);
		baseLine.material = material;
		baseLine.SetVertexCount(baseSegments);
		
		// Set the point positions.
		float segmentAngle = baseAngle / (baseSegments - 1);
		float startAngle = -baseAngle / 2;
		float angle = 0;
		Vector3 pointPosition;
		for (int i = 0; i < baseSegments; i++) {
			angle = startAngle + (segmentAngle * i);
			pointPosition = new Vector3(Mathf.Cos(angle) * baseRadius,
			                            Mathf.Sin(angle) * baseRadius,
			                            0.0f);
			baseLine.SetPosition(i, pointPosition);
		}
	}

	protected void CreateNeck() {
		// Create the object
		neckObject = new GameObject();
		neckObject.transform.position = transform.position;
		neckObject.name = "Neck";
		neckObject.transform.parent = transform;
		
		// Create the line renderer
		neckLine = neckObject.AddComponent<LineRenderer>();
		neckLine.useWorldSpace = false;
		neckLine.SetWidth(neckWidth, 0.0f);
		neckLine.material = material;
		neckLine.SetVertexCount(2);
		
		// Inner Pos.
		neckLine.SetPosition(0, new Vector3(baseRadius, 0.0f, 0.0f));
		
		// Outer Pos.
		neckLine.SetPosition(1, new Vector3(baseRadius + neckLength, 0.0f, 0.0f));
	}



	// Update Functions

	protected IEnumerator MarkerUpdate () {
		while (true) {
			// Follow the target;
			PointAtLocation(targetLocation, targetIsRelative);
			yield return new WaitForSeconds(trackingUpdateDelay);
		}
	}

	/*protected IEnumerator UpdateDirection() {
		PointAtLocation(targetLocation, targetIsRelative);
		yield return new WaitForSeconds(trackingUpdateDelay);
	}*/
	
	public void EnableMarker () {
		baseLine.enabled = true;
		neckLine.enabled = true;
	}
	
	public void DisableMarker () {
		baseLine.enabled = false;
		neckLine.enabled = false;
	}

	protected void PointAtLocation(Vector3 location) {
		PointAtLocation(location, false);
	}

	protected void PointAtLocation(Vector3 location, bool isRelative) {
		if (isRelative) {
			location += transform.position;
		}

		transform.LookAt(location);
	}
}
