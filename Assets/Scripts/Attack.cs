using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public float speed;
	public PlatformerCharacter2D player;
	public int PointsForKill;
	public float rotationSpeed;
	public int damageValue;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlatformerCharacter2D> ();

		if (player.transform.localScale.x < 0) {
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().position.y);
		GetComponent<Rigidbody2D> ().angularVelocity = rotationSpeed;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			//Destroy (other.gameObject);
			//Collectables.AddPoints(PointsForKill);
			other.GetComponent<EnemyHP>().giveDamage(damageValue);
		}
	}
}
