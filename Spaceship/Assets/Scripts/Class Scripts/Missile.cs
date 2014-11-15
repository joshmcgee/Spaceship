using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Missile : Projectile {

	public bool doesSwarm;
	public List<Missile> swarmMissile = new List<Missile>();
	public int swarmCount;
	public float swarmActivationDistance;
	public float swarmActivationEffect;
}
