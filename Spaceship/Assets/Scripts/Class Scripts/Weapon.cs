using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapon : Module {

	public enum AmmoType {
		PROJECTILE,
		PLASMA,
		PULSE_LASER,
		BEAM_LASER,
		LIGHT_MISSILE,
		TORPEDO
	}

	public AmmoType ammoType;
	public float launchVelocity;

	public float maxRange;
	public float accuracyAngle;

	public int vollySize;
	public float vollyReloadTime;
	public float burstReloadTime;
	public float barrelDelay;

	public bool doesTrackTarget;
	public float trackingAngle;
	public float trackingSpeed;
	public float trackingRange;

	public List<TurretBarrel> barrels = new List<TurretBarrel>();
}
