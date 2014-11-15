using UnityEngine;
using System.Collections;

public class Module : Ship {

	public enum Size {
		SMALL,
		MEDIUM,
		LARGE,
		CAPITAL
	}

	public Size size;
	public float angle;
}
