using UnityEngine;
using System.Collections;

public class reflectionManager : MonoBehaviour {

	GameObject image;

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
		image.GetComponent<SpriteRenderer> ().sprite = this.GetComponent<SpriteRenderer> ().sprite;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
