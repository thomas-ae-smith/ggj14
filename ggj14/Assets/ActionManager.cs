using UnityEngine;
using System.Collections;

public class ActionManager : MonoBehaviour {

	public string prompt;
	public Sprite evil;
	public int cost, payback;
	private GameObject image;


	// Use this for initialization
	void Start () {
		image = new GameObject("Reflection");
		image.transform.parent = this.transform;
		Vector3 pos = this.transform.position;
		pos.y = -pos.y;
		image.transform.position = pos;
		Vector3 theScale = image.transform.localScale;
		theScale.y *= -1;
		image.transform.localScale = theScale;
		//		image.transform.position.y = -image.transform.position.y;
		image.AddComponent<SpriteRenderer> ();
		image.GetComponent<SpriteRenderer> ().sprite = evil;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
