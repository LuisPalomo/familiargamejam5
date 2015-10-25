using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	private int score;

    private bool buckOpen=false;

    private string buttonBucket;

	public AudioClip buttonSound;

	public AudioClip exitSound;

	public AudioClip musicSound;

	public AudioClip cashSound;

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

        #if UNITY_STANDALONE_WIN
            this.ActivateQuitButton();
        #endif
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            if (Application.loadedLevelName == "MainMenu")
            {
                this.SetGuiItemsEnabled("Instructions", false);
                this.SetGuiItemsEnabled("Credits", false);
            }
        }
    }

    public void changeScene(string scene)
    {
		SoundManager.instance.PlaySingle (buttonSound);
        Application.LoadLevel(scene);
    }

    public void showHowToPlay()
    {
		SoundManager.instance.PlaySingle (buttonSound);
        this.SetGuiItemsEnabled("Instructions", true);
    }

    public void ShowCredits()
    {
		SoundManager.instance.PlaySingle (buttonSound);
        this.SetGuiItemsEnabled("Credits", true);
    }
    
    private void SetGuiItemsEnabled(string tag, bool enabledState)
    {
        GameObject[] howToCosas = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject howToItem in howToCosas)
        {
            if (howToItem.tag == tag)
                howToItem.SetActive(enabledState);
        }
    }

    private void ActivateQuitButton()
    {
        GameObject[] objectList = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject item in objectList)
        {
            if (item.tag == "QuitButton")
                item.SetActive(enabled);
        }
    }

    public void quitGame()
    {
		SoundManager.instance.PlaySingle(exitSound);
		Invoke ("closeGame", 2.5f);
    }

	public void closeGame()
	{
		Debug.Log ("CLOSE");
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
		if (newScore > 0)
        {
			SoundManager.instance.PlaySingleDelay(cashSound, 0.5F);
		} 
		else 
		{
			SoundManager.instance.PlaySingleDelay (exitSound, 0.5F);
		}
		score += newScore;
        UpdateScore();
    }

}