using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float countingTime;
	public float startingTime;
	private Text theText;
	private PauseMenu thePauseMenu;
	public string gameOver;

	// Use this for initialization
	void Start () {

		countingTime = startingTime;
		theText = GetComponent<Text> ();
		thePauseMenu = FindObjectOfType<PauseMenu>();
	}
	
	// Update is called once per frame
	void Update () {

		if (thePauseMenu.isPaused) {
			return;
		}
		
		countingTime -= Time.deltaTime;

		if (countingTime <= 0) {
			Application.LoadLevel(gameOver);
		}
		
		theText.text = "" + Mathf.Round (countingTime);
	}

	public void ResetTime() {

		countingTime = startingTime;
	}
}