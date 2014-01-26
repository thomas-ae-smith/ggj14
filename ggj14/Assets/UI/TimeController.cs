using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {

	private static int minutes = 7*60 + 30;

	// Use this for initialization
	void Start () {
		GetComponent<GUIText> ().text = "" + System.DateTime.Now.Hour%12 + ":" + System.DateTime.Now.Minute;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<GUIText> ().text = "" + minutes/60 + ":" + minutes%60;
	}

	public static void addMinutes(int mins) {
		minutes += mins;
	}
}
