using UnityEngine;
using System.Collections;

public class adjustMood : MonoBehaviour 
{
	
	public Camera main, reflection;
	public GameObject particles;
	public GUIText prompt;
	private Camera top, bottom;
	bool positive = true;
	private float mood = 0.5f;
	private float targetMood = 0.5f;
	private float deltaMood = -0.001f;
	
	
	void Awake ()
	{
		top = main;
		bottom = reflection;
		main.aspect = 1 / mood * 16 / 9;
		reflection.aspect = 1 / (1-mood) * 16 / 9;
		GL.SetRevertBackfacing (!positive);
		Vector3 pos = particles.transform.position;
		pos.y = 2.5f;
		particles.transform.position = pos;

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
		Vector3 pos = particles.transform.position;
		pos.y = tmp.y;
		particles.transform.position = pos;

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
	


	private void Adjust(bool check = true)
	{
		top.ResetProjectionMatrix ();
		bottom.ResetProjectionMatrix ();
		Rect tmp = main.rect;
//		tmp.y -= 0.01f;
		tmp.height = mood;
		main.rect = tmp;
		main.orthographicSize = 2*mood;
//		main.orthographicSize += 0.02f;

//		Vector3 tmp2 = main.transform.position;
//		tmp2.y = 2*mood;
//		main.transform.position = tmp2;

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

//		tmp2 = reflection.transform.position;
//		tmp2.y = -2*(1-mood);
//		reflection.transform.position = tmp2;

		reflection.aspect = 1 / (1-mood) * 16 / 9;

		tmp = top.rect;
		tmp.y = bottom.rect.height;
		top.rect = tmp;

		Vector3 pos = particles.transform.position;
		pos.y = 5*tmp.y;
		particles.transform.position = pos;


		if (mood > 0.6 && !positive && check)
		{
			Flip ();
		}
		if (mood < 0.4 && positive && check)
		{
			Flip ();
		}

		if (!positive)
		{
			top.projectionMatrix = top.projectionMatrix * Matrix4x4.Scale(new Vector3 (1, -1, 1));
			bottom.projectionMatrix = bottom.projectionMatrix * Matrix4x4.Scale(new Vector3 (1, -1, 1));
		}
	}

	public void Increase(float value)
	{
		mood = Mathf.Min(0.85f, mood + value);
		Adjust(true);
	}

	public void Decrease(float value)
	{
		mood = Mathf.Max(0.15f, mood - value);
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
		// If the current color of the screen is not equal to the desired color: keep fading!
		if (mood != targetMood)
		{			
			// If the difference between the current alpha and the desired alpha is smaller than delta-alpha * deltaTime, then we're pretty much done fading:
			if (Mathf.Abs(mood - targetMood) < Mathf.Abs(deltaMood) * Time.deltaTime)
			{
				targetMood = mood = (targetMood + mood)/2;
				Adjust();
				deltaMood = -0.001f;
			
			}
			else
			{
				// Fade!
				mood = mood + deltaMood * Time.deltaTime;
				Adjust();
			}
		} else {
			mood -= 0.001f;
//			Debug.Log(mood);
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
			StartAdjustment(0.15f, 2.0f);
		}
	}

	public void StartAdjustment(float diff, float time)
	{
		if (mood != targetMood){
			mood = targetMood;
		}
		targetMood = Mathf.Max (0.15f, Mathf.Min (0.85f, mood + diff));
		
		
		deltaMood = (targetMood - mood) / time;	
	}

	public void SetPrompt(string promptText)
	{
		prompt.text = promptText;
		prompt.enabled = true;
	}

	public void HidePrompt()
	{
		prompt.enabled = false;
	}
}
