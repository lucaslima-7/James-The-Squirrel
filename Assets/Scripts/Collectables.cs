using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Collectables : MonoBehaviour {
	
	public static int score;
	Text text;

	void Start(){
		text = GetComponent<Text> ();
		score = 0;
	}

	void Update(){
		if (score < 0)
			score = 0;

		text.text = "" + score;
	}

	public static void AddPoints (int PointsToAdd){
		score += PointsToAdd;
	}

	// public static void Reset(){ Colocar soh se quiser que o player perca todas as nozes depois de morrer
	//	score = 0;
	// }
}
