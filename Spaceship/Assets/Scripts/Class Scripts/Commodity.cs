using UnityEngine;
using System.Collections;

[System.Serializable]
public class CommodityProperties {
	public int metaLevel;
	public float mass;
	public float volume;
	public float baseCost;
}

[System.Serializable]
public class Commodity : Item {

	public CommodityProperties commodityProperties;
}
