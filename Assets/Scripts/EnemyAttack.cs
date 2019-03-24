using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float speed;
	public PlatformerCharacter2D player;
	public LevelManager levelManager;
	public float rotationSpeed;
	public Rigidbody2D enemy_rigidbody2D;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlatformerCharacter2D> ();
		levelManager = FindObjectOfType<LevelManager> ();
		enemy_rigidbody2D = GetComponent<Rigidbody2D> ();

		if (player.transform.position.x < transform.position.x) {
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}
	
	}

	void Update() {
		enemy_rigidbody2D.velocity = new Vector2 (speed, enemy_rigidbody2D.velocity.y);
		enemy_rigidbody2D.angularVelocity = rotationSpeed;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			levelManager.Respawn();
		}
	}
}