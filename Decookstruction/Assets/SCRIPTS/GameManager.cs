﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

    public float timeWatch;

    private float timeT,min,sec,mSec;

	private int score;

    private bool buckOpen=false;

    private string buttonBucket;
    public Text scor;

    private GameManager() { }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                DontDestroyOnLoad(instance);
                instance = new GameManager();
            }

            return instance;
        }
    }

	//Awake is always called before any Start functions
    void Awake()
    {
        Debug.Log("Inicia");
		//Check if instance already exists
		if (instance == null)
			
			//if not, set instance to this
			instance = this;
		
		//If instance already exists and it's not this:
		else if (instance != this)
			
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    
		
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        stopWatchF();
    }

    public void stopWatchF()
    {
        
        timeT=Time.time;

        Debug.Log(timeT);

        min = timeT / 60;

        sec = timeT % 60;

        mSec = (timeT * 100) % 100;

        Debug.Log(timeWatch);
    }

    public void changeScene(string scene){
        Application.LoadLevel(scene);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void setBuckOpen(bool buck)
    {
        this.buckOpen = buck;
    }

    public bool getBuckOpen()
    {
        return buckOpen;
    }

    public void setButtonBuck(string b)
    {
        this.buttonBucket = b;
    }

    public string getButtonBuck()
    {
        return buttonBucket;
    }
}