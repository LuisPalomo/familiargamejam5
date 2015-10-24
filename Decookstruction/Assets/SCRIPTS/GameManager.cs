using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

    public float timeT=180;

    private int min,sec,mSec;

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
        if (Application.loadedLevelName.Equals("GameScene"))
        {
            if (Input.GetButtonDown("jump"))
            {
                UpdateScore();
            }
        }
    }

    public float stopWatchF(float timeT)
    {
        timeT -= Time.deltaTime;

        if (timeT>0)
        {
            min = (int)timeT / 60;

            sec = (int)timeT % 60;

            mSec = (int)(timeT * 100) % 100;

            Debug.Log(min + " " + sec + " " + mSec);
        }

        return timeT;
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

	void UpdateScore()
	{
		GameObject scoreTextGO = GameObject.Find ("Score Text");
		scoreTextGO.GetComponent<Text>().text = score + " $";
	}

	public void AddScore(int newScore)
	{
		score += newScore;
	}
}
