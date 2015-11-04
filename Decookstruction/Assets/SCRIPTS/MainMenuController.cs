using System;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private Animator animator;

    private int showInstructionsParameter;
    private int showOptionsParameter;
    private int showCreditsParameter;

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

}