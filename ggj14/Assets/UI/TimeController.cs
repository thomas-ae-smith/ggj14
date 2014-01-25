using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<GUIText> ().text = "" + System.DateTime.Now.Hour%12 + ":" + System.DateTime.Now.Minute;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
