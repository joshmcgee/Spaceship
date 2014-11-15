using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Satellite : Ship {

	public Transform parentBody;
	public float orbitDistance;
	public float yearLength;

	public List<Satellite> satellites = new List<Satellite>();
}
