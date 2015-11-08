using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private Animator animator;
    
    private int showInstructionsParameter;
    private int showOptionsParameter;
    private int showCreditsParameter;
    
    public enum MainMenuState
    {
        MainScreen,
        InstructionsScreen,
        OptionsScreen,
        CreditsScreen
    }
    
    public MainMenuState State
    {
        get
        {
            if (this.animator.GetBool(showInstructionsParameter)) return MainMenuState.InstructionsScreen;
            if (this.animator.GetBool(showOptionsParameter)) return MainMenuState.OptionsScreen;
            if (this.animator.GetBool(showCreditsParameter)) return MainMenuState.CreditsScreen;
            return MainMenuState.MainScreen;
        }
    }
    
    private void Awake()
    {
        this.animator = this.GetComponent<Animator>();
        
        this.showInstructionsParameter = Animator.StringToHash("ShowInstructions");
        this.showOptionsParameter = Animator.StringToHash("ShowOptions");
        this.showCreditsParameter = Animator.StringToHash("ShowCredits");
    }
    
    public void ShowInstructions()
    {
        this.animator.SetBool(this.showInstructionsParameter, true);
    }
    
    public void ShowOptions()
    {
        this.animator.SetBool(this.showOptionsParameter, true);
    }
    
    public void ShowCredits()
    {
        this.animator.SetBool(this.showCreditsParameter, true);
    }
    
    public void ReturnToMain()
    {
        this.animator.SetBool(this.showInstructionsParameter, false);
        this.animator.SetBool(this.showOptionsParameter, false);
        this.animator.SetBool(this.showCreditsParameter, false);
    }
    
    public void SetGuiLanguage(string lang)
    {
        GameLocalization.CurrentLanguage = lang;
        this.TrySetText("Main screen/Start game/Start game text", "button-startgame");
        this.TrySetText("Main screen/Options/Options text", "button-options");
        this.TrySetText("Main screen/How to play/How to play text", "button-instructions");
        this.TrySetText("Main screen/Credits/Credits text", "button-credits");
        this.TrySetText("Main screen/Quit/Quit text", "button-quit");
    }
    
    private void TrySetText(string textName, string stringId)
    {
        Transform transform = this.transform.Find(textName);
        if (transform != null)
        {
            Text text = transform.GetComponent<Text>();
            if (text != null)
                text.text = GameLocalization.GetString(stringId);
        }
    }
    
}