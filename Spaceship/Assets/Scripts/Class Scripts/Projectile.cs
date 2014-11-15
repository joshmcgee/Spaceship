using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : Ship {

	public enum Size {
		SMALL,
		MEDIUM,
		LARGE,
		CAPITAL
	}

	public Size size;
	public List<Damage> damageTypes = new List<Damage>();
}
