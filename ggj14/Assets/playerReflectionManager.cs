using UnityEngine;
using System.Collections;

public class playerReflectionManager : MonoBehaviour {

	public GameObject obj;

	// Use this for initialization
	void Start () {
		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
		transform.localScale = theScale;
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<SpriteRenderer>().sprite = obj.GetComponent<SpriteRenderer>().sprite;
		Vector3 pos = this.transform.position;
		pos.y = -obj.transform.position.y;
		this.transform.position = pos;
		
	}
}
