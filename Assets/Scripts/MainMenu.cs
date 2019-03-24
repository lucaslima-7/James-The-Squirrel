using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string James_The_Squirrel;

	public void NewGame(){
		Application.LoadLevel (James_The_Squirrel);
	}

	public void QuitGame(){
		Application.Quit();
	}
}
