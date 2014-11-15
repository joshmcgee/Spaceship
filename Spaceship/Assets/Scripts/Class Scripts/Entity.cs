using UnityEngine;
using System.Collections;

[System.Serializable]
public class SpriteProperties {
	public Sprite sprite;
	public float scale = 1.0f;
}

public class Entity {
	
	public SpriteProperties spriteProperties;
}
