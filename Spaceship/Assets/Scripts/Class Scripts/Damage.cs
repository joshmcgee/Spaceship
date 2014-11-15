using UnityEngine;
using System.Collections;

public class Damage : Item {

	public enum Type {
		KINETIC,
		THERMAL,
		EM,
		PLASMA,
		ARMOR_PIERCING
	}

	public Type type;
	public int amount;
}
