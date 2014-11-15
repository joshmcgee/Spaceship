using UnityEngine;
using System.Collections;

[System.Serializable]
public class IllistrativeProperties {
	public enum Faction {
		FACTION_GOOD,
		FACTION_BAD,
		FACTION_UGLY
	};
	
	public enum Category {
		SMALL,
		MEDIUM,
		LARGE
	}
	
	public string internalName;
	public string displayName;
	public string pluralName;
	
	public string description;
	public Faction faction;
	public Category category;
}

[System.Serializable]
public class Item : Entity {

	public IllistrativeProperties illistrativeProperties;
	
}
