using UnityEngine;
using System.Collections;

[System.Serializable]
public class ComponentProperties {

	public Item item;
	public int quantity;
}

[System.Serializable]
public class MeasuredComponent : Item {

	public ComponentProperties componentProperties;
}
