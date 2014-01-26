using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public float xMargin;		// Distance in the x axis the player can move before the camera follows.
	public float yMargin;		// Distance in the y axis the player can move before the camera follows.
	public float xSmooth;		// How smoothly the camera catches up with it's target movement in the x axis.
	public float ySmooth;		// How smoothly the camera catches up with it's target movement in the y axis.
//	public Vector2 maxXAndY;		// The maximum x and y coordinates the camera can have.
//	public Vector2 minXAndY;		// The minimum x and y coordinates the camera can have.
	
	
	private Transform player;		// Reference to the player's transform.
	public Camera reflection;

	
	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -2);
		reflection.transform.position = new Vector3(transform.position.x, -transform.position.y, -2);


	}


	bool CheckXMargin()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
	}
	
	
	bool CheckYMargin()
	{
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
	}
	
	
	void Update ()
	{
		TrackPlayer();

	}
	
	
	void TrackPlayer ()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float minOrtho = Mathf.Min (reflection.orthographicSize, camera.orthographicSize);
		float targetY = Mathf.Max (player.position.y, minOrtho);
		
		// If the player has moved beyond the x margin...
		if(CheckXMargin())
			// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
			targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
		
//		 If the player has moved beyond the y margin...
//		if(CheckYMargin())
//			// ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
//			targetY = Mathf.Lerp(transform.position.y, Mathf.Max (player.position.y, minOrtho), ySmooth * Time.deltaTime);
		
		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, targetY - minOrtho + camera.orthographicSize, transform.position.z);
		reflection.transform.position = new Vector3(targetX, -(targetY - minOrtho + reflection.orthographicSize), transform.position.z);
//		reflection.transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
	}
}
