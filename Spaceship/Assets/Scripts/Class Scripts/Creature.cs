using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Creature : MonoBehaviour {

	public enum Profession {
		JANITOR,
		PILOT,
		ENGINEER,
		COOK,
		HOUSEWIFE,
		PET,
		VERMIN
	}

	public int intelligence;
	public int strength;
	public int reflexes;
	public int bravery;

	public float sneakSpeed;
	public float walkSpeed;
	public float runSpeed;

	public List<Item> likedItems = new List<Item>();
	public List<Item> dislikedItems = new List<Item>();

	public float happiness;

	public Profession profession;
	public Item workLocation; // Need to figure this out.

	public List<Creature> companions = new List<Creature>();
	public Item homeLocation; // Need to figure this out.


}
