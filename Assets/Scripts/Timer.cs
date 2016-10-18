using UnityEngine;

//A countdown time class
public class Timer
{
	float time; //duration to count down
	float endTime; //the end of the timer

	public void SetAndStartTimer(float t){
		time = t;
		endTime = Time.fixedTime + time;
	}

	public bool CheckTimer(){
		if (Time.fixedTime > endTime)
			return true; //the timer has run off
		else
			return false;
	}


	//Produces a random float number between min and max
	public static float RandomDuration(float min, float max)
	{
		float duration;
		duration = Random.Range (min, max);
		return duration;
	}
}

