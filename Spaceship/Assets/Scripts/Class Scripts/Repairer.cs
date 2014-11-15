using UnityEngine;
using System.Collections;

public class Repairer : Module {

	public enum Type {
		HULL,
		ARMOR,
		SHIELD
	}

	public Type type;
	public int repairAmount;
	public float cycleTime;
}
