using UnityEngine;
using System.Collections;

public class SoundControl : MonoBehaviour {

	AudioSource HappySource;
	AudioSource OkaySource;
	AudioSource SadSource;
	AudioSource DepressedSource;

	public GameObject HappyObject;
	public GameObject OkayObject;
	public GameObject SadObject;
	public GameObject DepressedObject;

	public AudioSource Current;
	public AudioSource Future;

	public float delay = 0.2f;

	// Use this for initialization
	void Start () {

		HappySource = HappyObject.GetComponent<AudioSource>();
		OkaySource = OkayObject.GetComponent<AudioSource>();
		SadSource = SadObject.GetComponent<AudioSource>();
		DepressedSource = DepressedObject.GetComponent<AudioSource>();

		HappySource.volume = 0;
		OkaySource.volume = 0;
		SadSource.volume = 0;
		DepressedSource.volume = 0;


		Current.volume = 1;



	
	}
	
	// Update is called once per frame
	void Update () {

		if (Future != Current)
			StartCoroutine(Crossfade(Current, Future, delay));

		if (Input.GetKey("1"))
			Future = HappySource;

		if (Input.GetKey("2"))
			Future = OkaySource;

		if (Input.GetKey ("3"))
			Future = SadSource;

		if (Input.GetKey ("4"))
			Future = DepressedSource;
	
	}

	IEnumerator Crossfade (AudioSource fadeout, AudioSource fadein, float timedelay)
	{
		fadeout.volume -= 0.001f ;
		fadein.volume += 0.001f;

		yield return new WaitForSeconds(timedelay);

		if (fadein.volume < 1)
			StartCoroutine(Crossfade(Current, Future, delay));
		if (fadein.volume >= 1)
		{
			Current = Future;
		}

	}
}
