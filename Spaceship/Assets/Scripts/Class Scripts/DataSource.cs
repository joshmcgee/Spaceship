using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class DataSource : MonoBehaviour{

	protected string dataFilePath;

	protected string commoditiesFilePath;
	public List<Commodity> commodities = new List<Commodity>();


	void Start () {

		dataFilePath = Application.dataPath + "/Data";

		commoditiesFilePath = dataFilePath + "/Commodities";
		LoadCommodities();
	}

	void LoadCommodities () {
		Debug.Log("Searching for Commodities Codex.");

		string codexPath = commoditiesFilePath + "/Commodities.codex";
		if (File.Exists(codexPath)) {
			Debug.Log("Found Codex!");

			string[] lines;
			//StreamReader reader = new StreamReader(codexPath);
			lines = File.ReadAllLines(codexPath);
			foreach (string line in lines) {
				Debug.Log("" + line);
			}
		}
		else {
			Debug.LogWarning("No Codex Found.");
		}
	}
}
