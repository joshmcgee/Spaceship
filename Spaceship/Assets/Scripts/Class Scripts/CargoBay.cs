using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class InventoryProperties {
	public List<Item> items = new List<Item>();
	public float maxVolume;
	//public List<Category> acceptedItemTypes = new List<Category>();
}

public class CargoBay : Module {

	public InventoryProperties inventoryProperties;
	
}
