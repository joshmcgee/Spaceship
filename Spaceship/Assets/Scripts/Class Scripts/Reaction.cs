using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ReactionProperties {
	public List<MeasuredComponent> ingredients = new List<MeasuredComponent>() ;
	public List<MeasuredComponent> products = new List<MeasuredComponent>();
	
	public float reactionTime;
	public int maxUses;
}

[System.Serializable]
public class Reaction : Commodity {

	public ReactionProperties reactionProperties;
}
