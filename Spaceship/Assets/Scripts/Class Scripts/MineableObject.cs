using UnityEngine;
using System.Collections;

public class MineableObject : Ship {

	public enum Ore {
		IRON_ORE,
		HEMATITE,
		BAUXITE,
		ICE
	}

	public Ore oreType;
	public int oreAmount;
}
