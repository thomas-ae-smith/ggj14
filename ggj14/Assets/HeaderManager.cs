using UnityEngine;
using System.Collections;

public class HeaderManager : MonoBehaviour {
	
	GameObject strike;
	public GameObject list;
	public adjustMood mood;
	bool complete = false;
	int tasks = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void finishTask()
	{
		tasks += 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (tasks >= 7 && !complete)
		{
			complete = true;
			Complete();
		}
	}
	
	public void Complete() {
		Debug.Log("complete");
		strike = (GameObject)Instantiate (this.gameObject);
		Destroy (strike.GetComponent<TaskManager> ());
		strike.GetComponent<GUIText> ().text = new string('-', (int)(gameObject.GetComponent<GUIText> ().text.Length + 2));;
		strike.transform.parent = this.transform;
//		CameraFade.StartAlphaFade( Color.white, false, 2f, 2f, () => 
//		                          { 
////			Destroy (list);
////			mood.enabled = false;
//			CameraFade.StartAlphaFade( Color.white, true, 2f, 0f, () => { } ); 
//		} );

		CameraFade.StartAlphaFade( Color.white, false, 2f, 0f, () => 
		                          { 
						Destroy (list);
						mood.enabled = false;

			CameraFade.StartAlphaFade( Color.white, true, 2f, 0f, () => 
			                          { 
//				Task.Complete (); 
			} ); 
		} );
	}
}
