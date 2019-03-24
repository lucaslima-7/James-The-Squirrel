using UnityEngine;
using System.Collections;

	public class PlatformerCharacter2D : MonoBehaviour
	{

		[SerializeField] private float maxSpeed = 10f; // O mais rapido que James pode se mover no eixo x
		[SerializeField] private float jumpForce = 400f; // O tanto de forca que o pulo vai ter (obs: pode estar relativo a gravidade)	
		public bool airControl = false; // Controle aereo e o quanto o jogador pode se mover em queda livre
		public LayerMask whatIsGround; // Uma mascara que preve o que eh chao, podendo ser determinado settando um layer.
		private bool facingRight = true; // Por default, o player inicia o jogo olhando para a direita
		private bool grounded = false; // James esta no chao?
		private bool jump; // Variavel que faz James pular, checando se o pulo eh verdadeiro ou nao
		private Transform groundCheck; // Checar se ha chao abaixo do personagem
		private float groundedRadius = .2f; // Tamanho do GroundCheck
		private Animator anim; // Pega o Animator de James
		public Transform firePoint;
		public GameObject Nut_Attack;

		void Awake(){
			groundCheck = transform.Find("GroundCheck");
			anim = GetComponent<Animator>();
		}
		
		
		void FixedUpdate(){
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
			anim.SetBool("Ground", grounded);
			anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

			float h = Input.GetAxis("Horizontal");
			Move(h, jump);
			jump = false;
		}
		
		
		public void Move(float move, bool jump){
			if (grounded || airControl){
				anim.SetFloat("Speed", Mathf.Abs(move));
				GetComponent<Rigidbody2D>().velocity = new Vector2(move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
				
				if (move > 0 && !facingRight){
						Flip();
					}
					else if (move < 0 && facingRight){
						Flip();
					}
			}
			
			if (grounded && jump && anim.GetBool("Ground")){
				grounded = false;
				anim.SetBool("Ground", false);
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
			}
		}
		
		
		public void Flip(){
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}

		void Update(){

		if (!jump){
			jump = Input.GetButtonDown ("Jump");
		}

		if (jump){
			GetComponent<AudioSource>().Play ();
		}

		if (Input.GetButtonDown ("Attack")){
			Instantiate (Nut_Attack, firePoint.position, firePoint.rotation);
		}
	}

		void OnCollisionEnter2D (Collision2D other){
			if (other.transform.tag == "MovingPlatform") {
				transform.parent = other.transform;
			}
		}

		void OnCollisionExit2D (Collision2D other){
			if (other.transform.tag == "MovingPlatform") {
				transform.parent = null;
			}
		}
}