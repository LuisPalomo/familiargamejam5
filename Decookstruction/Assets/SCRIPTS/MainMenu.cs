using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void StartGame(){
		Application.LoadLevel("GameScene");
	}

	public void HowToPlay(){
		//Time.timeScale = 0.5;
	}

	public void Quit(){
		Application.Quit();
	}
}
