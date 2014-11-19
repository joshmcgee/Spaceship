using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class WeaponBarrel {

	public Transform barrelTransform;
	[Space(10)]

	//public Vector3 muzzlePosition;
	//public Vector2 muzzleDirection;
	public Transform muzzleTransform;
	//public Effect muzzleEffect;
	[Space(10)]

	public float recoilDistance;
	public float recoilResetTime;
}

public class MountedWeapon : MonoBehaviour {

	public enum AmmoType {
		Bullet,
		Plasma,
		Laser,
		Missile
	}

	public AmmoType ammoType;
	public float launchVelocity;
	[Space(10)]

	public float maxRange;
	public float accuracyAngle;
	[Space(10)]

	public int vollySize;
	public float vollyReloadTime;
	public float burstReloadTime;
	public float barrelDelay;
	[Space(10)]

	public List<WeaponBarrel> barrels = new List<WeaponBarrel>();
	private List<Laser> lasers = new List<Laser>();
	[Space(20)]

	[Header("Temporary")]
	public Transform projectile;


	// Use this for initialization
	void Start () {
		GetAmmo();
	}

	void GetAmmo () {
		switch (ammoType) {
		case AmmoType.Laser :
			CreateLasers();
			break;
		}
	}

	void CreateLasers () {
		foreach (WeaponBarrel barrel in barrels) {
			Transform laserTrans = Instantiate(projectile, barrel.muzzleTransform.position, barrel.muzzleTransform.rotation) as Transform;
			Laser laser = laserTrans.GetComponent<Laser>();
			if (laser != null) {
				laserTrans.name = "Laser";
				laserTrans.parent = barrel.muzzleTransform;
				laser.maxRange = maxRange;
				lasers.Add(laser);
			}
			else {
				Debug.LogError("No Laser component found on projectile.");
			}


		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
