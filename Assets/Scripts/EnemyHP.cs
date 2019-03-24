using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour {

	public int HP;
	public int pointsOnDeath;
	public string mainMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (HP <= 0) {
			Collectables.AddPoints (pointsOnDeath);
			Destroy (gameObject);

			if (gameObject.name == "Jarbas"){
				Application.LoadLevel (mainMenu);
			}
		}
	}

	public void giveDamage (int damage){
		HP -= damage;
	}
}
