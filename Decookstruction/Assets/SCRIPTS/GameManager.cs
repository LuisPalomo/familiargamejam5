using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    
    private int score;
    
    private bool buckOpen = false;
    
    private bool block = false;
    
    private string buttonBucket;
    
    // Sonidos del juego
    public AudioClip buttonSound;
    public AudioClip cashSound;
    public AudioClip exitSound;
    public AudioClip musicSound;
    
    // Controlador de menú principal
    private MainMenuController mainMenuController;
    
    private GameManager()
    {
    }
    
    public static GameManager Instance
    {
        get
        {
            //if (instance == null)
            //{
            //    DontDestroyOnLoad(instance);
            //    instance = new GameManager();
            //}
            
            return GameManager.instance;
        }
    }
    
    // Métodos de Unity
    void Awake()
    {
        //Debug.Log("Inicia");
        
        if (GameManager.instance == null)
            GameManager.instance = this;
        else if (GameManager.instance != this)
            GameObject.Destroy(this.gameObject);    
        
        // No destruir con los cambios de escena
        GameObject.DontDestroyOnLoad(this.gameObject);
        
        this.mainMenuController = this.FindMainMenuController();
        
        #if UNITY_STANDALONE_WIN
            this.ActivateQuitButton();
        #endif
        
        // Cargar localización
        TextAsset localizationXml = Resources.Load<TextAsset>("Language");
        GameLocalization.LoadLocalizationXmlFromText(localizationXml.text);
    }
    
    private void Update()
    {
        if (Input.anyKey)
        {
            if (Application.loadedLevelName == "MainMenu")
            {
                if ((GameManager.Instance.mainMenuController.State ==
                        MainMenuController.MainMenuState.InstructionsScreen) ||
                    (GameManager.Instance.mainMenuController.State ==
                        MainMenuController.MainMenuState.CreditsScreen))
                
                GameManager.Instance.mainMenuController.ReturnToMain();
            }
        }
        
        //if (Input.GetKeyUp(KeyCode.E)) GameManager.Instance.mainMenuController.SetGuiLanguage("es");
        //if (Input.GetKeyUp(KeyCode.N)) GameManager.Instance.mainMenuController.SetGuiLanguage("en");
    }
    
    private void OnLevelWasLoaded(int level)
    {
        if (Application.loadedLevelName == "MainMenu")
        {
            GameManager.Instance.mainMenuController = this.FindMainMenuController();
            SoundManager.instance.PlayMusicMenu();
        }
        else
            SoundManager.instance.PlayMusicGame();
    }
    
    // Métodos auxiliares
    private MainMenuController FindMainMenuController()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("MainMenuCanvas");
        if (canvas != null)
            return canvas.GetComponent<MainMenuController>();
        
        return null;
    }
    
    public void SetGuiItemsEnabled(string tag, bool enabledState)
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
    
    public bool Block
    {
        get { return block; }
        set { block = value; }
    }
    
    void UpdateScore()
    {
        GameObject scoreTextGO = GameObject.Find("Score Text");
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
            SoundManager.instance.PlaySingleDelay(exitSound, 0.5F);
        }
        Debug.Log("Score " + score);
        Debug.Log("NewScore " + newScore);
        score += newScore;
        Debug.Log("ScoreFinal " + score);
        UpdateScore();
    }
    
    public void UpdateTotalScore()
    {
        GameObject scoreTextGO = GameObject.Find("Score");
        scoreTextGO.GetComponent<Text>().text = score + " $";
    }
    
    // Eventos del menú principal del juego
    public void ChangeScene(string scene)
    {
        SoundManager.instance.PlaySingle(buttonSound);
        //Debug.Log("CambioScena");
        
        // Desbloquear y resetear puntuación
        GameManager.Instance.Block = false;
        GameManager.Instance.score = 0;
        //Debug.Log("Nuevo Score: " + score);
        
        // Cambiar de escena
        Application.LoadLevel(scene);
    }
    
    public void ReturnToMainScreen()
    {
        SoundManager.instance.PlaySingle(buttonSound);
        GameManager.Instance.mainMenuController.ReturnToMain();
    }
    
    public void ShowInstructions()
    {
        SoundManager.instance.PlaySingle(buttonSound);
        GameManager.Instance.mainMenuController.ShowInstructions();
    }
    
    public void ShowOptions()
    {
        SoundManager.instance.PlaySingle(buttonSound);
        GameManager.Instance.mainMenuController.ShowOptions();
    }
    
    public void ShowCredits()
    {
        SoundManager.instance.PlaySingle(buttonSound);
        GameManager.Instance.mainMenuController.ShowCredits();
    }
    
    public void QuitGame()
    {
        SoundManager.instance.PlaySingle(exitSound);
        Invoke("closeGame", 2.5f);
    }
    
}