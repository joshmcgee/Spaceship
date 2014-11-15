using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : Commodity {
	
	public int baseShield;
	public int baseArmor;
	public int baseHull;

	public float basePowergrid;
	public float baseCPU;
	public float baseCapacitor;

	public List<Hardpoint> weaponHardpoints = new List<Hardpoint>();
	public List<Hardpoint> engineHardpoints = new List<Hardpoint>();
	public List<Hardpoint> thrusterHardpoints = new List<Hardpoint>();
	public List<Hardpoint> dockingHardpoints = new List<Hardpoint>();
	public List<Hardpoint> utilityHardpoints = new List<Hardpoint>();
	public List<Hardpoint> navLightHardpoints = new List<Hardpoint>();
}
