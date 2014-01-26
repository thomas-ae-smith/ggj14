using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour {

	public AudioClip Happy;
	public AudioClip Okay;
	public AudioClip Sad;
	public AudioClip Depressed;
	

	public AudioSource HappySource;
	public AudioSource OkaySource;
	public AudioSource SadSource;
	public AudioSource DepressedSource;

	GameObject HappyPlayer;
	GameObject OkayPlayer;
	GameObject SadPlayer;
	GameObject DepressedPlayer;

	int CurrentTrack = 4;
	int FutureTrack = 1;

	public AudioSource fadein;
	public AudioSource fadeout;

	/* 
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

	}


	void Start () {

		/*Don't need the GameObject declaration type in the bits below - it's been done above. To 
		 * do it again would be to infer that this variable (e.g. HappyPlayer) is local and not public
		 * as described above, and therefore inaccessible to all other functions.*/

		//Setup Happy Music
		HappyPlayer = new GameObject();
		HappyPlayer.transform.position = transform.position;
		HappyPlayer.transform.parent = transform;
		HappySource = HappyPlayer.AddComponent<AudioSource>();
		HappySource.loop = true;
		HappySource.clip = Happy;
		HappySource.volume = 0;
		HappySource.Play ();
		
		//Setup Okay music		 
		OkayPlayer = new GameObject();
		OkayPlayer.transform.position = transform.position;
		OkayPlayer.transform.parent = transform;
		OkaySource = OkayPlayer.AddComponent<AudioSource>();
		OkaySource.loop = true;
		OkaySource.clip = Okay;
		OkaySource.volume = 0f;
		OkaySource.Play ();
		
		//Setup Melancholy Music
		SadPlayer = new GameObject();
		SadPlayer.transform.position = transform.position;
		SadPlayer.transform.parent = transform;
		SadSource = SadPlayer.AddComponent<AudioSource>();
		SadSource.loop = true;
		SadSource.clip = Sad;
		SadSource.volume = 0;
		SadSource.Play ();
		
		//Setup Depressed Music
		DepressedPlayer = new GameObject();
		DepressedPlayer.transform.position = transform.position;
		DepressedPlayer.transform.parent = transform;
		DepressedSource = DepressedPlayer.AddComponent<AudioSource>();
		DepressedSource.loop = true;
		DepressedSource.clip = Depressed;
		DepressedSource.volume = 0;
		DepressedSource.Play ();


		FutureTrack = 3;
		CurrentTrack = 3;
	}
	
	// Update is called once per frame
	void Update () {

		/*
		if (Input.GetKey("1")){
			HappySource.volume = 1;
			OkaySource.volume = 0;
			SadSource.volume = 0;
			DepressedSource.volume = 0;
		}
		if (Input.GetKey("2")){
			HappySource.volume = 0;
			OkaySource.volume = 1;
			SadSource.volume = 0;
			DepressedSource.volume = 0;
		}
		if (Input.GetKey("3")){
			HappySource.volume = 0;
			OkaySource.volume = 0;
			SadSource.volume = 1;
			DepressedSource.volume = 0;
		}
		if (Input.GetKey("4")){
			HappySource.volume = 0;
			OkaySource.volume = 0;
			SadSource.volume = 0;
			DepressedSource.volume = 1;
		}
*/

		if(Input.GetKey("1"))
			FutureTrack = 1;

		if (Input.GetKey("2"))
			FutureTrack = 2;

		if (Input.GetKey("3"))
			FutureTrack = 3;

		if (Input.GetKey("4"))
			FutureTrack = 4;
	
		if (CurrentTrack ==1)
			fadeout = HappySource;
		if (CurrentTrack == 2)
			fadeout = OkaySource;
		if (CurrentTrack == 3)
			fadeout = SadSource;
		if (CurrentTrack == 4)
			fadeout = DepressedSource;

		if (FutureTrack == 1)
			fadein = HappySource;
		if (FutureTrack == 2)
			fadein = OkaySource;
		if (FutureTrack == 3)
			fadein = SadSource;
		if (FutureTrack == 4)
			fadein = DepressedSource;

		if (FutureTrack != CurrentTrack)
		{
			StartCoroutine(CrossFade(fadeout, fadein, 0.2f));
		}

	}

	IEnumerator CrossFade (AudioSource outgoing, AudioSource incoming, float timedelay)
	{
		yield return new WaitForSeconds (timedelay);
		outgoing.volume += 0.1f;
		incoming.volume -= 0.1f;
		if(incoming.volume<1)
			StartCoroutine(CrossFade(outgoing, incoming, 0.2f));
		if(incoming.volume>=1)
			CurrentTrack = FutureTrack;
	}


}

