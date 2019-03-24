using UnityEngine;
using System.Collections;

public class Nuts : MonoBehaviour {

	public int pointsToAdd;
	public AudioSource NutSoundEffect;

	void OnTriggerEnter2D (Collider2D other){
		if (other.GetComponent<PlatformerCharacter2D> () == null)
			return;

		Collectables.AddPoints (pointsToAdd);
		NutSoundEffect.Play();
		Destroy (gameObject);
	}
}
