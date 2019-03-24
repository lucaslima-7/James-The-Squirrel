using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	public string mainMenu;
	public GameObject GameOver;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NewGame() {
		Application.LoadLevel (mainMenu);
	}
}
