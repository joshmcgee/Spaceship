using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThrusterController : MonoBehaviour {

	//public List<Sprite> emissionSprites = new List<Sprite>();

	//public float emissionWidth;
	public float emissionLength;

	public float pulseSizeChange;
	public float pulseFrequency;

	// Use this for initialization
	void Start () {
		emissionLength = transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
