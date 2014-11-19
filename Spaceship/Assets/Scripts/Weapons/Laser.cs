using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Damage {
	public enum DamageType {
		ArmorPierce,
		Heat,
		Explosive,
		Kinetic,
		ElectroMagnetic
	}
	
	public DamageType damageType;
	public float damageAmount;
}


public class Laser : MonoBehaviour {

	public Material laserMaterial;
	private float _maxRange;
	public float maxRange {
		get {return _maxRange; }
		set {
			_maxRange = value;
			if (beamRenderer == null) {
				GetBeamRenderer();
			}
			SetBeamEndPoint();
		}
	}
	[Space(10)]

	//public Effect launchEffect;
	//public Effect hitEffect;
	//[Space(10)]

	public List<Damage> damages = new List<Damage>();

	protected LineRenderer beamRenderer;
	protected Ray2D beamRay;
	protected Vector2 beamEndPoint;




	// Use this for initialization
	void Start () {
		GetBeamRenderer();
	}

	void GetBeamRenderer() {
		beamRenderer = GetComponent<LineRenderer>();
		if (beamRenderer == null) {
			Debug.LogWarning("No laser renderer found, creating a new one.") ;

			beamRenderer = this.gameObject.AddComponent<LineRenderer>();
			beamRenderer.useWorldSpace = false;
			beamRenderer.SetWidth(0.05f, 0.05f);
			beamRenderer.material = laserMaterial;
			beamRenderer.SetColors(Color.white, new Color(1f, 1f, 1f, 0f));
			beamRenderer.SetVertexCount(2);
			beamRenderer.SetPosition(0, Vector3.zero);
			beamRenderer.SetPosition(1, new Vector3(0, maxRange, 0));
		}
	}

	void SetBeamEndPoint () {
		beamRenderer.SetPosition(1, new Vector3(0, maxRange, 0));
	}

	void DrawBeam () {

	}
	
	// Update is called once per frame
	void Update () {
		
		UpdateBeam();
	}

	void UpdateBeam () {

		Vector3 worldPoint = transform.TransformPoint(transform.position + (Vector3.up * maxRange));
		beamEndPoint = new Vector2(worldPoint.x, worldPoint.y);
		//Debug.DrawLine(transform.position, beamEndPoint, Color.yellow);


		Debug.DrawRay(transform.position, beamEndPoint);
		//beamRay.direction = new Vector2(beamEndPoint.x, beamEndPoint.y);

		Debug.Log("Laser layer => " + gameObject.layer);
		RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), beamEndPoint, maxRange, gameObject.layer);


	}
}
