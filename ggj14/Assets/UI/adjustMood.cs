﻿using UnityEngine;
using System.Collections;

public class adjustMood : MonoBehaviour 
{
	
	public Camera main, reflection;
	private Camera top, bottom;
	bool positive = true;
	private float mood = 0.5f;
	
	
	void Awake ()
	{
		top = main;
		bottom = reflection;
		main.aspect = 32/9;
		reflection.aspect = 32/9;
		GL.SetRevertBackfacing (!positive);

	}
	
	private void Flip()
	{
		positive = !positive;

		Camera swap = top;
		top = bottom;
		bottom = swap;
		Rect tmp = top.rect;
		tmp.y = bottom.rect.y;
		top.rect = tmp;
		tmp = bottom.rect;
		tmp.y = 0;
		bottom.rect = tmp;

//		top.transform.eulerAngles = new Vector3(180, 0, 180); 
//		bottom.transform.eulerAngles = new Vector3(180, 0, 180); 

//		top.projectionMatrix = top.projectionMatrix * Matrix4x4.Scale(new Vector3 (1, -1, 1));
//		bottom.projectionMatrix = bottom.projectionMatrix * Matrix4x4.Scale(new Vector3 (1, -1, 1));
		GL.SetRevertBackfacing (!positive);

//		top.orthographicSize *= -1;
//		bottom.orthographicSize *= -1;

//		top.rect.Set (0, bottom.rect.y, 1, top.rect.height);
//		bottom.rect.Set (0, 0, 1, bottom.rect.height);
//		main.transform.localScale.Set (1, -main.transform.localScale.y, 1);

	}
	


	private void Adjust()
	{
		top.ResetProjectionMatrix ();
		bottom.ResetProjectionMatrix ();
		Rect tmp = main.rect;
//		tmp.y -= 0.01f;
		tmp.height = mood;
		main.rect = tmp;
		main.orthographicSize = 2*mood;
//		main.orthographicSize += 0.02f;
		Vector3 tmp2 = main.transform.position;
		tmp2.y = 2*mood;
		main.transform.position = tmp2;
		main.aspect = 1 / mood * 16 / 9;
		//		main.aspect = 1f/tmp.y;
		//		tmp = reflection.rect;
		//		tmp.y -= 0.01f;
		//		reflection.rect = tmp;

		tmp = reflection.rect;
		tmp.height = 1-mood;
		reflection.rect = tmp;
		reflection.orthographicSize = 2*(1-mood);
//		reflection.orthographicSize -= 0.02f;
		tmp2 = reflection.transform.position;
		tmp2.y = -2*(1-mood);
		reflection.transform.position = tmp2;
		reflection.aspect = 1 / (1-mood) * 16 / 9;

		tmp = top.rect;
		tmp.y = bottom.rect.height;
		top.rect = tmp;

		if (mood > 0.6 && !positive)
		{
			Flip ();
		}
		if (mood < 0.4 && positive)
		{
			Flip ();
		}

		if (!positive)
		{
			top.projectionMatrix = top.projectionMatrix * Matrix4x4.Scale(new Vector3 (1, -1, 1));
			bottom.projectionMatrix = bottom.projectionMatrix * Matrix4x4.Scale(new Vector3 (1, -1, 1));
		}
	}

	private void Increase()
	{
		mood = Mathf.Min(0.9f, mood + 0.01f);
		Adjust();
	}

	private void Decrease()
	{
		mood = Mathf.Max(0.1f, mood - 0.01f);
		Adjust();
	}
	
//	private void Decrease()
//	{
//		Rect tmp = main.rect;
////		tmp.y += 0.01f;
//		tmp.height -= 0.01f;
//		main.rect = tmp;
//		top.orthographicSize -= (positive)? 0.02f : -0.02f;
////		main.orthographicSize -= 0.02f;
//		Vector3 tmp2 = main.transform.position;
//		tmp2.y -= 0.02f;
//		main.transform.position = tmp2;
//		main.aspect = 1 / tmp.height * 16 / 9;
//		//		main.aspect = 1f;
//		//		tmp = reflection.rect;
//		//		tmp.y += 0.01f;
//		//		reflection.rect = tmp;
//
//		tmp = reflection.rect;
//		tmp.height += 0.01f;
//		reflection.rect = tmp;
//		bottom.orthographicSize += (positive)? 0.02f : -0.02f;
////		reflection.orthographicSize += 0.02f;
//		tmp2 = reflection.transform.position;
//		tmp2.y -= 0.02f;
//		reflection.transform.position = tmp2;
//		reflection.aspect = 1 / tmp.height * 16 / 9;
//
//		tmp = top.rect;
//		tmp.y = bottom.rect.height;
//		top.rect = tmp;

//		if (main.rect.height < 0.4 && positive)
//		{
//			Flip ();
//		}
//	}

	void Update ()
	{
		
		float move = Input.GetAxis("Vertical");
		
		if (move > 0)
		{
			Increase();
		}
		else if (move < 0)
		{
			Decrease();
		}
	}

}