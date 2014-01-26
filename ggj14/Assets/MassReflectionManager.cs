using UnityEngine;
using System.Collections;

public class MassReflectionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject image;
		Vector3 pos;
		foreach (Transform child in transform)
		{
			// do whatever you want with child transform object here
			image = (GameObject)Instantiate(child.gameObject);
//			, new Vector3(child.transform.position.x, child.transform.position.y, 1), child.transform.rotation);
			image.transform.parent = child.transform;
			pos = image.transform.position;
			pos.y = -pos.y;
			image.transform.position = pos;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
