using UnityEngine;
using System.Collections;

public class TargetCamera : MonoBehaviour {

	public Transform target;

	public bool matchPosition = true;
	public bool matchRotation = false;

	public float zoomSpeed = 5f;
	public float minZoom = 5;
	public float maxZoom = 800;

	// Use this for initialization
	void Start () {
		//camera.orthographicSize = Screen.height / 2;

	}

	void Update () {
		//camera.orthographicSize += inpu
		camera.orthographicSize -= Input.GetAxis("Mouse Scrollwheel") * zoomSpeed;
		if (camera.orthographicSize < minZoom) {
			camera.orthographicSize = minZoom;
		}
		else if (camera.orthographicSize > maxZoom) {
			camera.orthographicSize = maxZoom;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (target) {
			if (matchPosition) {
				transform.position = new Vector3(target.position.x,
				                                 target.position.y,
				                                 transform.position.z);
			}

			if (matchRotation) {
				transform.rotation = target.rotation;
			}
		}
	}
}
