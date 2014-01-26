using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour {

	public AudioClip Happy;
	public AudioClip Okay;
	public AudioClip Sad;
	public AudioClip Depressed;

	public GameObject AudioController;

	public AudioSource HappySource;
	public AudioSource OkaySource;
	public AudioSource SadSource;
	public AudioSource DepressedSource;
	

	/* public AudioSource HappySong;
	public AudioSource OkaySong;
	public AudioSource SadSong;
	public AudioSource DepressedSong;
============================================
	GameObject audioObj = new GameObject();
	audioObj.transform.position = targetObj.transform.position;
	audioObj.transform.parent = targetObj.transform;		// add to parent
	AudioSource source = audioObj.AddComponent<AudioSource>();
	source.clip = audioClip;
	source.volume = 100;
	source.Play();
	Destroy(audioObj, audioClip.length);
=============================================

	 */	

	void Awake (){

		//Setup Happy Music
		GameObject HappyPlayer = new GameObject();
		HappyPlayer.transform.position = transform.position;
		HappyPlayer.transform.parent = transform;
		AudioSource HappySource = HappyPlayer.AddComponent<AudioSource>();
		HappySource.loop = true;
		HappySource.clip = Happy;
		HappySource.volume = 0;
		HappySource.Play ();
		
		//Setup Okay music		 
		GameObject OkayPlayer = new GameObject();
		OkayPlayer.transform.position = transform.position;
		OkayPlayer.transform.parent = transform;
		AudioSource OkaySource = OkayPlayer.AddComponent<AudioSource>();
		OkaySource.loop = true;
		OkaySource.clip = Okay;
		OkaySource.volume = 0f;
		OkaySource.Play ();
		
		//Setup Melancholy Music
		GameObject SadPlayer = new GameObject();
		SadPlayer.transform.position = transform.position;
		SadPlayer.transform.parent = transform;
		AudioSource SadSource = SadPlayer.AddComponent<AudioSource>();
		SadSource.loop = true;
		SadSource.clip = Sad;
		SadSource.volume = 0;
		SadSource.Play ();
		
		//Setup Depressed Music
		GameObject DepressedPlayer = new GameObject();
		DepressedPlayer.transform.position = transform.position;
		DepressedPlayer.transform.parent = transform;
		AudioSource DepressedSource = DepressedPlayer.AddComponent<AudioSource>();
		DepressedSource.loop = true;
		DepressedSource.clip = Depressed;
		DepressedSource.volume = 1;
		DepressedSource.Play ();



	}


	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("1"))
		{
			Debug.Log("1 pressed");
			HappySource.volume = 1;
			OkaySource.volume = 0;
			SadSource.volume = 0;
			DepressedSource.volume = 0;
		}
	
	}
}
