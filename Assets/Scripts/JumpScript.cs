using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour {

	public float force;
	public GameController controller;
	private PlayerScript ps;
	private GameObject currentRestBar;
	private Rigidbody2D rb;



	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		ps = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript> ();


	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("jump script");
		if (Input.GetKeyDown (KeyCode.Space)) {
			//prevent double jump
			Debug.Log ("in key down : " + rb.velocity.y );
			Debug.Log(rb.velocity.y );
			if (rb.velocity.y <= 0.1) {
				rb.AddForce (new Vector2 (0, force));
			}
		}
	}

	void OnCollisionEnter2D(Collision2D  other) {		
		ps.SetCurrentPlatform (other.gameObject);
	}


}
