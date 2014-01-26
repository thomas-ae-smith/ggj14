using UnityEngine;
using System.Collections;

public class TaskManager : MonoBehaviour {

	public HeaderManager header;
	GameObject strike;
	bool complete = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown(KeyCode.H) && !complete) {
//			complete = true;
//			Debug.Log("input");
//			CameraFade.StartAlphaFade( Color.black, false, 2f, 0f, () => { TimeController.addMinutes(45); CameraFade.StartAlphaFade( Color.black, true, 2f, 1f, () => { Complete (); } ); } );
////			Complete();
//		}
	}

	public void Complete() {
		Debug.Log("complete");
		strike = (GameObject)Instantiate (this.gameObject);
		Destroy (strike.GetComponent<TaskManager> ());
		strike.GetComponent<GUIText> ().text = "  " + new string('-', (int)(gameObject.GetComponent<GUIText> ().text.Length));;
		strike.transform.parent = this.transform;
		header.finishTask ();
	}
}
