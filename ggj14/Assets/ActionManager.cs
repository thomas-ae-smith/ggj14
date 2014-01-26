using UnityEngine;
using System.Collections;

public class ActionManager : MonoBehaviour {

	public string promptText;
	public TaskManager Task;
	public adjustMood Mood;
	public Sprite evil;
	public float cost, gain;
	private GameObject image;
	private bool possible = false;
	private bool completed = false;


	// Use this for initialization
	void Start () {
		image = new GameObject ("Reflection");
		image.transform.parent = this.transform;
		Vector3 pos = this.transform.position;
		pos.y = -pos.y;
		image.transform.position = pos;
		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
//		theScale.x *= -1;
		image.transform.localScale = theScale;
		Quaternion rot = transform.rotation;
		image.transform.rotation = rot;
		//		image.transform.position.y = -image.transform.position.y;
		image.AddComponent<SpriteRenderer> ();
		image.GetComponent<SpriteRenderer> ().sprite = evil;
		this.gameObject.AddComponent<BoxCollider2D> ().isTrigger = true;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis("Vertical") > 0 && possible && !completed)
		{
			completed = true;
			Mood.StartAdjustment(-cost, 2f);
//			Mood.Decrease(cost);
			CameraFade.StartAlphaFade( Color.black, false, 2f, 0f, () => 
			{ 
				TimeController.addMinutes(45); 
				Mood.HidePrompt();
				image.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
				Mood.StartAdjustment(cost + gain, 2f);
//				Mood.Increase(cost+gain);
				CameraFade.StartAlphaFade( Color.black, true, 2f, 0f, () => 
				{ 
					Task.Complete (); 
				} ); 
			} );
		}
	}

	void OnTriggerEnter2D() {
		if (!completed) {
			Mood.SetPrompt (promptText);
		}
//		Debug.Log ("Shower?");
		possible = true;
	}

	void OnTriggerExit2D() {
		Mood.HidePrompt ();
		possible = false;
	}
	
}
