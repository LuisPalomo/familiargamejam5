using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour {

    public Text stopWatchText;

    public float timeT = 180;

    private int min, sec, mSec;

	public Color alertColor;

	public AudioSource lastSeconds;

	private Boolean lastSecondsPlayed = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        stopWatchF(timeT);
	}

    public void stopWatchF(float timeTe)
    {
        this.timeT -= Time.deltaTime;

        if (timeTe > 0)
        {
            min = (int)timeTe / 60;

            sec = (int)timeTe % 60;

            mSec = (int)(timeTe * 100) % 100;

            //Debug.Log(min + " : " + sec + " : " + mSec);

        }

		if (sec == 5) 
		{
			stopWatchText.color = alertColor;
			if(!lastSecondsPlayed)
			{
				lastSeconds.Play();
				lastSecondsPlayed = true;
			}
		}

        //stopWatchText.text= min + " : " + sec + " : " + mSec;
		stopWatchText.text = sec.ToString();
    }
}
