using UnityEngine;
using System.Collections;

public class Planet : Satellite {

	public enum Climate {
		TEMPERATE,
		OCEAN,
		DESERT,
		GAS,
		LAVA,
		ICE
	}

	public int population;
	public Climate climate;
	public float dayLength;
}
